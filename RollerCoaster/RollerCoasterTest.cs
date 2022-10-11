namespace RollerCoaster;

public class RollerCoasterShould
{
    [Theory(DisplayName = "Compute total gain")]
    [ClassData(typeof(RollerCoasterTheoryData.SampleDataset))]
    public void Compute_total_gain(
        int attractionPlacesCount,
        int attractionRidesCount,
        int[] personsGroupsCount,
        long totalDirhamsEarned)
        => GetTotalDirhamsEarned(attractionPlacesCount, attractionRidesCount, personsGroupsCount)
            .Should()
            .Be(totalDirhamsEarned);

    [Theory(DisplayName = "Manage large dataset")]
    [ClassData(typeof(RollerCoasterTheoryData.LargeDataset))]
    public void Manage_large_dataset(
        int attractionPlacesCount,
        int attractionRidesCount,
        int[] personsGroupsCount,
        long totalDirhamsEarned)
        => GetTotalDirhamsEarned(attractionPlacesCount, attractionRidesCount, personsGroupsCount)
            .Should()
            .Be(totalDirhamsEarned);

    [Theory(DisplayName = "Execution time < 500ms")]
    [ClassData(typeof(RollerCoasterTheoryData.SampleDataset))]
    [ClassData(typeof(RollerCoasterTheoryData.LargeDataset))]
    public void Performed_under_500ms(
        int attractionPlacesCount,
        int attractionRidesCount,
        int[] personsGroupsCount,
        long _)
        => this.ExecutionTimeOf(
                _ => GetTotalDirhamsEarned(attractionPlacesCount, attractionRidesCount, personsGroupsCount))
            .Should()
            .BeLessThan(500.Milliseconds());

    private static long GetTotalDirhamsEarned(
        int attractionPlacesCount,
        int attractionRidesCount,
        int[] personsGroupsCount)
    {
        var groupsCount = personsGroupsCount.Length;

        var rideResultsByQueuePosition = new Dictionary<int, RideResult>();
        var totalDirhamsEarned = 0L;
        var queuePosition = 0;

        for (var i = 0; i < attractionRidesCount; i++)
        {
            RideResult rideResult;
            if (rideResultsByQueuePosition.ContainsKey(queuePosition))
            {
                rideResult = rideResultsByQueuePosition[queuePosition];
            }
            else
            {
                rideResult = GetDirhamsEarnedAndNewQueuePositionForARide(
                    groupsCount,
                    personsGroupsCount,
                    queuePosition,
                    attractionPlacesCount);
                
                rideResultsByQueuePosition.Add(queuePosition, rideResult);
            }


            totalDirhamsEarned += rideResult.DirhamsEarned;
            queuePosition = rideResult.QueuePosition;
        }

        return totalDirhamsEarned;
    }

    private static RideResult GetDirhamsEarnedAndNewQueuePositionForARide(
        int groupsCount,
        int[] personsGroupsCount,
        int queuePosition,
        int attractionAvailablePlacesCount)
    {
        var groupsInAttractionCount = 0;
        var dirhamsEarned = 0L;

        while (attractionAvailablePlacesCount >= personsGroupsCount[queuePosition])
        {
            var isAllGroupsInAttraction = groupsInAttractionCount++ >= groupsCount;
            if (isAllGroupsInAttraction)
                break;

            var personsCount = personsGroupsCount[queuePosition];
            dirhamsEarned += personsCount;
            attractionAvailablePlacesCount -= personsCount;

            if (++queuePosition >= groupsCount)
                queuePosition = 0;
        }

        return new RideResult(dirhamsEarned, queuePosition);
    }
}

public class RideResult
{
    public RideResult(long dirhamsEarned, int queuePosition)
    {
        DirhamsEarned = dirhamsEarned;
        QueuePosition = queuePosition;
    }

    public long DirhamsEarned { get; }
    public int QueuePosition { get; }
}