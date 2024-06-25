using System;
using System.Threading.Channels;
using System.Threading.Tasks;

public class UberRide
{
    private readonly Channel<int> riderChannel = Channel.CreateUnbounded<int>();
    private readonly Channel<int> driverChannel = Channel.CreateUnbounded<int>();

    public async Task Rider(int riderId)
    {
        Console.WriteLine($"Putnik {riderId} čeka vozača.");
        await riderChannel.Writer.WriteAsync(riderId);
        var driverId = await driverChannel.Reader.ReadAsync();
        Console.WriteLine($"Putnik {riderId} je spojen sa vozačem {driverId}.");
    }

    public async Task Driver(int driverId)
    {
        Console.WriteLine($"Vozač {driverId} čeka putnika.");
        await driverChannel.Writer.WriteAsync(driverId);
        var riderId = await riderChannel.Reader.ReadAsync();
        Console.WriteLine($"Vozač {driverId} je spojen sa putnikom {riderId}.");
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        var uberRide = new UberRide();

        var riders = new Task[5];
        var drivers = new Task[5];

        for (int i = 0; i < 5; i++)
        {
            int riderId = i + 1;
            riders[i] = uberRide.Rider(riderId);
        }

        for (int i = 0; i < 5; i++)
        {
            int driverId = i + 1;
            drivers[i] = uberRide.Driver(driverId);
        }

        await Task.WhenAll(riders);
        await Task.WhenAll(drivers);
    }
}
