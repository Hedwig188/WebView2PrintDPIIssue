using Microsoft.Web.WebView2.Core;
using System.Windows;

namespace WebView2PrintDPIIssue
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			InitializeWebView();
		}

		private async void InitializeWebView()
		{
			await webView.EnsureCoreWebView2Async();
			webView.CoreWebView2.NavigationCompleted += PrintDocument;
		}

		private void PrintDocument(object sender, CoreWebView2NavigationCompletedEventArgs args)
		{
			CoreWebView2PrintSettings printSetting = CreatePrinterSetting("Adobe PDF");
			webView.CoreWebView2.PrintAsync(printSetting);
		}

		private CoreWebView2PrintSettings CreatePrinterSetting(string printerName)
		{
			CoreWebView2PrintSettings printerSettings = webView.CoreWebView2.Environment.CreatePrintSettings();
			printerSettings.PrinterName = printerName;
			return printerSettings;
		}
	}
}
