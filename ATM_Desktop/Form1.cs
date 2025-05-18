using ATMService;

namespace ATM_Desktop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var pin = txtPIN.Text;


            ATMService.ATMService service = new ATMService.ATMService();

            var result = service.ValidateAccount(userName, pin);

            if (result)
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
