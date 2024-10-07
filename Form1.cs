namespace TSTag3000 {
	public partial class Form1 : Form {
		public static Form1 form;
		public Form1() {
			InitializeComponent();
			form = this;
			//dont allow resizing
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;

			try {
				TIOS.Init();
				TIOS.LoadDatabase();
			}
			catch(Exception e) {
				MessageBox.Show(e.ToString());
			}
		}
		public static int currentPage = 0;
		public static StartPage startPage;
		public static ManagePage managePage;
		public static void LoadSearchPage() {
			if(startPage == null) {
				startPage = new StartPage();
			}
			/*remove all controls from the form and add StartPage*/
			form.Controls.Clear();
			form.Controls.Add(new StartPage());

			form.Size = new Size(916, 710);

			form.Form1_Resize(null, null);
		}
		public static void LoadManagePage() {
			if(managePage == null) {
				managePage = new ManagePage();
			}
			/*remove all controls from the form and add MainPage*/

			form.FormBorderStyle = FormBorderStyle.Sizable;
			form.MaximizeBox = true;

			currentPage = 1;
			form.Controls.Clear();
			form.Controls.Add(managePage);

			form.Form1_Resize(null, null);
		}

		//Windows border size
		public const int HORIZONTAL_BORDER = 16;
		public const int VERTICAL_BORDER = 39;
		private void Form1_Resize(object sender, EventArgs e) {
			if(currentPage == 1) {
				managePage.Width = this.Width - HORIZONTAL_BORDER;
				managePage.Height = this.Height - VERTICAL_BORDER;
			}
		}
	}
}
