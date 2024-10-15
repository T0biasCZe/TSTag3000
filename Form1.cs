using TSTag3000.db;
using TSTag3000.UI;
using static TSTag3000.UI.AeroUtil;

namespace TSTag3000
{
    public partial class Form1 : Form {
		public static Form1 form;
		public Form1() {
			Settings.LoadSettings();
			try {
				Database.Init();
			}
			catch(Exception e) {
				MessageBox.Show(e.ToString());
			}



			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			InitializeComponent();
			form = this;
			//dont allow resizing
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
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

			if(Settings.managePageMaximized) {
				Form1.form.WindowState = FormWindowState.Maximized;
			}
			else if(Settings.managePageSize != null) {
				Form1.form.Size = Settings.managePageSize;
			}
			else {
				Form1.form.Size = new Size(1120 + HORIZONTAL_BORDER, 680 + VERTICAL_BORDER);
			}

			form.FormBorderStyle = FormBorderStyle.Sizable;
			form.MaximizeBox = true;

			currentPage = 1;
			form.Controls.Clear();
			form.Controls.Add(managePage);

			form.MinimumSize = new Size(640, 480);

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
		public static void OnProcessExit(object sender, EventArgs e) {
			Settings.SaveSettings();
			Database.SaveShutdown();
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			AeroUtil.ApplyBlurEffect(this.Handle);

			Rectangle rect = new Rectangle(0, 88, this.Width, this.Height - 88);
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), rect);
		}
	}
}
