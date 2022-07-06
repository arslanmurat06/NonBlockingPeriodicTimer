

var backgrountask = new BackgroundTimer(TimeSpan.FromMilliseconds(100));

Console.WriteLine("Press a key to start");
Console.ReadKey();

backgrountask.Start();

Console.WriteLine("Press a key to cancel");
Console.ReadKey();

await backgrountask.StopAsync();


