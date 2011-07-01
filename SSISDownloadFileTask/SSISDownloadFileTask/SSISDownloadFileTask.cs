using System;
using System.ComponentModel;
using System.IO;
using System.Xml;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using DTSExecResult = Microsoft.SqlServer.Dts.Runtime.DTSExecResult;
using DTSProductLevel = Microsoft.SqlServer.Dts.Runtime.DTSProductLevel;
using VariableDispenser = Microsoft.SqlServer.Dts.Runtime.VariableDispenser;

namespace SSISDownloadFileTask100.SSIS
{
    [DtsTask(
        DisplayName = "Download File Task",
        UITypeName = "SSISDownloadFileTask100.SSISDownloadFileTaskUIInterface" +
        ",SSISDownloadFileTask100," +
        "Version=1.1.0.0," +
        "Culture=Neutral," +
        "PublicKeyToken=fe104a4a72746eeb",
        IconResource = "SSISDownloadFileTask100.DownloadIcon.ico",
        TaskContact = "cosmin.vlasiu@gmail.com",
        RequiredProductLevel = DTSProductLevel.None
        )]
    public class SSISDownloadFileTask : Task, IDTSComponentPersist
    {
        #region Constructor
        public SSISDownloadFileTask()
        {
        }

        #endregion

        #region Public Properties
        [Category("General"), Description("The connector associated with the task")]
        public string HttpConnector { get; set; }
        [Category("General"), Description("Http Source File")]
        public string HttpSourceFile { get; set; }
        [Category("General"), Description("Local Destination File")]
        public string LocalDestinationFile { get; set; }
        #endregion

        #region Private Properties

        Variables _vars = null;

        #endregion

        #region Validate

        /// <summary>
        /// Validate local parameters
        /// </summary>
        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser,
                                               IDTSComponentEvents componentEvents, IDTSLogging log)
        {
            bool isBaseValid = true;

            if (base.Validate(connections, variableDispenser, componentEvents, log) != DTSExecResult.Success)
            {
                componentEvents.FireError(0, "SSISDownloadFileTask", "Base validation failed", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(HttpConnector))
            {
                componentEvents.FireError(0, "SSISDownloadFileTask", "A connector is required.", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(HttpSourceFile))
            {
                componentEvents.FireError(0, "SSISDownloadFileTask", "A source file (direct file URL) is required.", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(LocalDestinationFile))
            {
                componentEvents.FireError(0, "SSISDownloadFileTask", "A destination file (local path) is required.", "", 0);
                isBaseValid = false;
            }

            return isBaseValid ? DTSExecResult.Success : DTSExecResult.Failure;
        }

        #endregion

        #region Execute

        /// <summary>
        /// This method is a run-time method executed dtsexec.exe
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="variableDispenser"></param>
        /// <param name="componentEvents"></param>
        /// <param name="log"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
        {
            bool refire = false;

            GetNeededVariables(variableDispenser, HttpSourceFile);
            GetNeededVariables(variableDispenser, LocalDestinationFile);

            componentEvents.FireInformation(0,
                                            "SSISDownloadFileTask",
                                            string.Format("Source File: \"{0}\", Destination File \"{1}\"",
                                                          EvaluateExpression(HttpSourceFile, variableDispenser),
                                                          EvaluateExpression(LocalDestinationFile, variableDispenser)),
                                            string.Empty,
                                            0,
                                            ref refire);

            try
            {
                componentEvents.FireInformation(0,
                                                "SSISDownloadFileTask",
                                                "Prepare variables",
                                                string.Empty,
                                                0,
                                                ref refire);

                componentEvents.FireInformation(0,
                                                "SSISDownloadFileTask",
                                                DownloadFile(connections, variableDispenser, componentEvents)
                                                    ? "The file has been downloaded successfully."
                                                    : "The file has NOT been downloaded.",
                                                string.Empty,
                                                0,
                                                ref refire);
            }
            catch (Exception ex)
            {
                componentEvents.FireError(0,
                                          "SSISDownloadFileTask",
                                          string.Format("Problem: {0}",
                                                        ex.Message),
                                          "",
                                          0);
            }
            finally
            {
                if (_vars.Locked)
                {
                    _vars.Unlock();
                }
            }

            return base.Execute(connections, variableDispenser, componentEvents, log, transaction);
        }

        private bool DownloadFile(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents)
        {
            bool retVal = false;

            try
            {
                object connInfoObject = connections[HttpConnector].AcquireConnection(null);

                if (connInfoObject == null)
                    throw new Exception(string.Format("Cannot Acquire HTTP Connection To the File {0}", HttpSourceFile));

                var httpClientConnection = new HttpClientConnection(connInfoObject)
                {
                    ServerURL = (string)EvaluateExpression(HttpSourceFile, variableDispenser)
                };

                httpClientConnection.DownloadFile((string)EvaluateExpression(LocalDestinationFile, variableDispenser), true);

                if (File.Exists((string)EvaluateExpression(LocalDestinationFile, variableDispenser)))
                    retVal = true;

            }
            catch (Exception exception)
            {
                retVal = false;
                componentEvents.FireError(0,
                                         "SSISDownloadFileTask",
                                         string.Format("Problem: {0}",
                                                       exception.Message),
                                         "",
                                         0);
            }

            return retVal;
        }

        #endregion

        #region Methods
        /// <summary>
        /// This method evaluate expressions like @([System::TaskName] + [System::TaskID]) or any other operation created using 
        /// ExpressionBuilder
        /// </summary>
        /// <param name="mappedParam"></param>
        /// <param name="variableDispenser"></param>
        /// <returns></returns>
        private static object EvaluateExpression(string mappedParam, VariableDispenser variableDispenser)
        {
            object variableObject = null;
            try
            {
                var expressionEvaluatorClass = new ExpressionEvaluatorClass
                {
                    Expression = mappedParam
                };

                expressionEvaluatorClass.Evaluate(DtsConvert.GetExtendedInterface(variableDispenser), out variableObject, false);
            }
            catch
            {
                variableObject = mappedParam;
            }

            return variableObject;
        }

        private void GetNeededVariables(VariableDispenser variableDispenser, string variableExpression)
        {
            try
            {
                var mappedParams = variableExpression.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < mappedParams.Length - 1; index++)
                {
                    var param = mappedParams[index].Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    variableDispenser.LockForRead(param.Substring(0, param.IndexOf(']')));
                }
            }
            catch
            {
                //We will continue...
            }

            variableDispenser.GetVariables(ref _vars);
        }

        #endregion

        #region Implementation of IDTSComponentPersist

        void IDTSComponentPersist.SaveToXML(XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement taskElement = doc.CreateElement(string.Empty, "SSISDownloadFileTask", string.Empty);

            XmlAttribute httpConnector = doc.CreateAttribute(string.Empty, Keys.HTTP_CONNECTOR, string.Empty);
            httpConnector.Value = HttpConnector;

            XmlAttribute httpSourceFile = doc.CreateAttribute(string.Empty, Keys.HttpSourceFile, string.Empty);
            httpSourceFile.Value = HttpSourceFile;

            XmlAttribute localDestinationFile = doc.CreateAttribute(string.Empty, Keys.LocalDestinationFile, string.Empty);
            localDestinationFile.Value = LocalDestinationFile;

            taskElement.Attributes.Append(httpConnector);
            taskElement.Attributes.Append(httpSourceFile);
            taskElement.Attributes.Append(localDestinationFile);

            doc.AppendChild(taskElement);
        }

        void IDTSComponentPersist.LoadFromXML(XmlElement node, IDTSInfoEvents infoEvents)
        {
            if (node.Name != "SSISDownloadFileTask")
            {
                throw new Exception("Unexpected task element when loading task.");
            }

            try
            {
                HttpConnector = node.Attributes.GetNamedItem(Keys.HTTP_CONNECTOR).Value;
                HttpSourceFile = node.Attributes.GetNamedItem(Keys.HttpSourceFile).Value;
                LocalDestinationFile = node.Attributes.GetNamedItem(Keys.LocalDestinationFile).Value;
            }
            catch
            {

            }
        }

        #endregion
    }
}
