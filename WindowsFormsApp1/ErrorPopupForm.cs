using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class ErrorPopupForm : Form
	{
		public ErrorPopupForm(string title, string msg)
		{
			InitializeComponent();

			Text = title;
			popupText.Text = msg;
		}
	}
}
