using System.Collections.Concurrent;

namespace Api.UnitTests;

public class MultiThreadPersonKataTests
{
    /*
     * An app that efficiently generates a prime number using multiple threads
     *given a range, generates a prime numbers within that range
     * 
     */
    public static List<int> GeneratePrimes(int start, int end)
    {
        var primes = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if(IsPrime(i)){ primes.Add(i);}
        }
        
        return primes;
    }
    
    public async static Task<List<int>> MultiThreadGeneratePrimes(int start, int end)
    {
        var primes = new ConcurrentBag<int>();
        var numThreads = 2; //Environment.ProcessorCount;
        var tasks = new Task[numThreads];
        
        var chunks = (end - start + 1) / numThreads; //5 - 0 + 1/2 = 2 remainder 1
        var remainder = (end - start + 1) % numThreads; //to handle left over
        
        for (var i = 0; i < numThreads; i++)
        {
            
                //get isPrime for each chunk
                int localStart = start + i * chunks; // 0, 5, 10 if chenk size is 5. i is the index into each chunk, start ensures right start
                int localEnd = (i == numThreads - 1) ? end: localStart + chunks - 1;
                tasks[i] = Task.Run(() =>
                {
                    for (int num = localStart; num <= localEnd; num++)
                    {
                        if (IsPrime(num)){primes.Add(num);}
                    }
                });
        }
        
        await Task.WhenAll(tasks);
        return primes.OrderBy(prime => prime).ToList();
    }

    /// <summary>
    /// It is not 1
    /// it is 2
    /// it is only divisible by itself and 1
    /// examples are 2,3,5,7,11,
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static bool IsPrime(int number)
    {
        if(number <= 1) { return false; }
        if(number <= 3) { return true; }
        if(number % 2 == 0 || number % 3 == 0) { return false; }

        
        for (int i = 5; i * i <= number; i += 6) //ensures we check only numbers of the form
                                                 // 6k + 1 or 6k - 1 (multiples of 6 + OR - 1
                                                // 5, 7, 11, 13
        {

            if (number % i == 0 || number % (i + 2) == 0)
            { //make sure 
                return false;
            }
        }
        
        return true;
    }
    
    [Fact]
    public void CanGeneratePrimes()
    {
        int start = 10;
        int end = 20;
        
        List<int> expectedPrimes = new List<int>() { 11,13,17,19 };

        var result = GeneratePrimes(start, end);
        
        Assert.Equal(expectedPrimes, result);
    }
    
    [Fact]
    public async Task CanMultiThreadGeneratePrimes()
    {
        int start = 10;
        int end = 20;
        
        List<int> expectedPrimes = new List<int>() { 11,13,17,19 };

        var result = await MultiThreadGeneratePrimes(start, end);
        
        Assert.Equal(expectedPrimes, result);
    }
}