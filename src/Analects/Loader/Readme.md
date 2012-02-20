To use the EmbedAssemblies.targets file, 
put the following line in your project file 
(usually near the bottom after any other imports):

    <Import Project="$(MSBuildProjectDirectory)\Analects\Loader\EmbedAssemblies.targets" />

The other thing to do is add a call to Loader.Initialize, as early as possible in your application.

Her is an example for WPF.

    [STAThread]
    public static void Main()
    {
        Loader.Initialize();
    
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }
