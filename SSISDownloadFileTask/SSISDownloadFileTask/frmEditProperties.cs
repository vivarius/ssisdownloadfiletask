using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.DataTransformationServices.Controls;
using Microsoft.SqlServer.Dts.Runtime;

namespace SSISDownloadFileTask100
{
    public partial class frmEditProperties : Form
    {
        #region Private Properties
        private TaskHost _taskHost;
        private Connections _connections;
        #endregion

        #region Public Properties
        private Variables Variables
        {
            get { return _taskHost.Variables; }
        }

        private Connections Connections
        {
            get { return _connections; }
        }

        #endregion

        #region .ctor
        public frmEditProperties(TaskHost taskHost, Connections connections)
        {
            InitializeComponent();

            _taskHost = taskHost;
            _connections = connections;

            if (taskHost == null)
            {
                //throw new ArgumentNullException("taskHost");
            }

            try
            {
                LoadFileConnections();

                cmbHttpConnectionManager.SelectedIndex = cmbHttpConnectionManager.FindString(_taskHost.Properties[NamedStringMembers.HTTP_CONNECTOR].GetValue(_taskHost).ToString());
                txSourceFile.Text = _taskHost.Properties[NamedStringMembers.HttpSourceFile].GetValue(_taskHost).ToString();
                txDestinationFile.Text = _taskHost.Properties[NamedStringMembers.LocalDestinationFile].GetValue(_taskHost).ToString();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Methods

        private void LoadFileConnections()
        {
            foreach (var connection in Connections.Cast<ConnectionManager>().Where(connection => connection.CreationName == "HTTP"))
            {
                cmbHttpConnectionManager.Items.Add(connection.Name);
            }
        }

        #endregion

        #region Events
        private void btExpressionSource_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_taskHost.Variables, _taskHost.VariableDispenser, typeof(string), txSourceFile.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    txSourceFile.Text = expressionBuilder.Expression;
                }
            }
        }

        private void btExpressionDestination_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_taskHost.Variables, _taskHost.VariableDispenser, typeof(string), txDestinationFile.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    txDestinationFile.Text = expressionBuilder.Expression;
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //Save the values
            _taskHost.Properties[NamedStringMembers.HTTP_CONNECTOR].SetValue(_taskHost, cmbHttpConnectionManager.Text);
            _taskHost.Properties[NamedStringMembers.HttpSourceFile].SetValue(_taskHost, txSourceFile.Text);
            _taskHost.Properties[NamedStringMembers.LocalDestinationFile].SetValue(_taskHost, txDestinationFile.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion
    }
}
