class BackgroundTimer {

    public  PeriodicTimer _timer { get; set; }
    public readonly CancellationTokenSource _ctx;
    private Task? _jobTask;

    public BackgroundTimer(TimeSpan interval)
    {
        _timer = new PeriodicTimer(interval);
        _ctx= new();
    }

    public void Start() 
        => _jobTask = DoWork();
    


    private async Task DoWork(){

        try
        {
            while((await _timer.WaitForNextTickAsync(_ctx.Token))){
                     //TODO: Do some job here
                        Console.WriteLine($"Job is being done at {DateTime.UtcNow} ");
                }
            }
        catch (OperationCanceledException)
        {}
       
    }

    public async Task StopAsync(){

        if(_jobTask == null)
            return;

        _ctx.Cancel();
          await _jobTask;
        _ctx.Dispose();
    }
}
