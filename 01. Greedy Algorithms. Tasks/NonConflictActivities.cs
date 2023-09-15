namespace Greedy_Algorithms
{

    public class Activity
    {
        public string ActivityName { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }


    internal class Program
    {
        static void Main()
        {
            List<Activity> activities = new List<Activity>
            {
                new Activity { ActivityName = "a1", StartTime = 1, EndTime = 3 },
                new Activity { ActivityName = "a2", StartTime = 0, EndTime = 4 },
                new Activity { ActivityName = "a3", StartTime = 1, EndTime = 2 },
                new Activity { ActivityName = "a4", StartTime = 4, EndTime = 6 },
                new Activity { ActivityName = "a5", StartTime = 2, EndTime = 9 },
                new Activity { ActivityName = "a6", StartTime = 5, EndTime = 8 },
                new Activity { ActivityName = "a7", StartTime = 3, EndTime = 5 },
                new Activity { ActivityName = "a8", StartTime = 4, EndTime = 5 }
            };

            List<Activity> selectedActivities = SelectNonConflictActivities(activities);

            Console.WriteLine("Max count nonconflict activities:");

            foreach (var activity in selectedActivities)
            {
                Console.WriteLine($"Activity: {activity.ActivityName}  =>  Start time: {activity.StartTime}  =>  End time: {activity.EndTime}");
            }
        }

        static List<Activity> SelectNonConflictActivities(List<Activity> activities)
        {
            List<Activity> selectedActivities = new List<Activity>();

            activities = activities.OrderBy(a => a.EndTime).ToList();

            selectedActivities.Add(activities[0]);

            int previousActivityEndTime = activities[0].EndTime;

            for (int i = 1; i < activities.Count; i++)
            {
                if (activities[i].StartTime >= previousActivityEndTime)
                {
                    selectedActivities.Add(activities[i]);
                    previousActivityEndTime = activities[i].EndTime;
                }
            }

            return selectedActivities;
        }
    }
}