using System.ComponentModel;
using System.Windows.Markup;

namespace Exam2
{
    internal class Program
    {
        // main method
        public static void Main(String[] args)
        {
            long views = generateViews();       // creates variable which is equal to views
            int numVids = getNumVideos();       // creates variable which is equal to user input of amount of videos


            // parallel array holds number of videos
            long[] genViews = new long[numVids];    // array to hold number of views
            long[] genLikes = new long[numVids];    // array to hold number of likes
            double[] likePercentages = new double[numVids];     // array to hold % of likes

            // populates arrays
            for (int i = 0; i < numVids; i++)
            {
                genViews[i] = generateViews();  // sets value of views array equal to amount of views
                genLikes[i] = generateLikes(genViews[i]);   // sets value of likes array equal to likes
                likePercentages[i] = calculateLikePct(genLikes[i], genViews[i]);    // sets value of likes % array equal to like percentage
                
            }
            // calls methods to output data
            displayStats(genViews, genLikes, numVids);
            maxViews(numVids, genViews);
            minViews(numVids, genViews);
            maxLikes(numVids, genLikes);
            minLikes(numVids, genLikes);
        }
        // method which gets user input on number of videos
        public static int getNumVideos()
        {
            // variable which holds user input for number of videos
            int ytVids;
           
            // prompts user with question of how many videos will be selected with range
            Console.Write("Enter the amount of videos that will be selected from Youtube (min: 1 - max: 9: ");
            // declares user input = to variable
            ytVids = Convert.ToInt32(Console.ReadLine());

            // do while loop which runs until user enters values 1 through 9
                do
                {
                    // validates user input
                    if (ytVids < 1 || ytVids > 9) 
                    {
                    // error code if user input is invalid
                    Console.WriteLine("ERROR: ENTER BETWEEN 1 AND 9 VIDEOS. TRY AGAIN");
                    Console.Write("Enter the amount of videos that will be selected from Youtube (min: 1 - max: 9: ");
                    ytVids = Convert.ToInt32(Console.ReadLine());
                    }           
                } while (ytVids < 1 || ytVids > 9);     
           
            return ytVids;
        }
        // method that creates a random number of views
        public static long generateViews()
        {
            // declares variable to hold number of views
            long numRandom;
           
            // creates random 'long type' number of views
            Random rand = new Random();
            numRandom= rand.Next();

            // returns random 'long type' number of views
            return numRandom;
        }
        // method that creates a random number of likes based on views
        public static long generateLikes(long genViews)
        {
            // declares variable to hold number of likes
            long numRandom = 0;

            // creates random which creates random number < amount of views
            Random rnd = new Random();
            numRandom = rnd.Next((int)genViews);
            
            // returns number of likes
            return numRandom;
          
        }
        // method that calculates the like percentage
        public static double calculateLikePct(long genLikes, long genViews)
        {
            // variable that holds the like %
            double likePCT = 0;

            // calculates the like %
            likePCT = (double)genLikes / genViews;

            // returns the like %
            return likePCT;
        }
        // method that calculates the most viewed video, and how many views that video had as well as outputting the data
        public static void maxViews(int numVids, long[] genViews)
        {
            // sets a highest views variable
            // creates variable equal to first value of parallel array
            int highestViews = (int)genViews[0];
            int vidIndex = 0;

            // loops through the rest of the array
            for (int i = 1; i < numVids; i++)
            {
                // if current value is more than the current most viewed video
                if (genViews[i] > highestViews)
                {
                    highestViews = (int)genViews[i];     // updates the max views
                    vidIndex = i;           // updates the index
                }
            }
            // outputs the most viewed input as well as which video #
            Console.WriteLine("\nMost Viewed Video\nVideo #" + (vidIndex + 1) + "\t" + highestViews.ToString("n0") + " views");
        }
        // method that calculates the least viewed video, and how many views that video had as well as outputting the data
        public static void minViews(int numVids, long[] genViews)
        {
            // sets a lowest views variable
            // creates variable equal to first value of parallel array
            int lowestViews = (int)genViews[0];
            int vidIndex = 0;

            // loops through the rest of the array
            for (int i = 1; i < numVids; i++)
            {
                // if current value is less than the current least viewed video
                if (genViews[i] < lowestViews)
                {
                    lowestViews = (int)genViews[i];     // updates the minimum views
                    vidIndex = i;           // updates the index
                }
            }
            // outputs the least viewed input as well as which video #
            Console.WriteLine("\nLeast Viewed Video\nVideo #" + (vidIndex + 1) + "\t" + lowestViews.ToString("n0") + " views");

        }
        // method that calculates the most liked video and which # video it is as well as outputting the data
        public static void maxLikes(int numVids, long[] genLikes)
        {
            // sets a max likes variable
            // creates variable equal to first value of parallel array
            long maxLikes = (int)genLikes[0];
            int vidIndex = 0;
            
            // loops through the rest of the array
            for (int i = 1; i < numVids; i++)
            {
                // if current value is more than the current most liked video
                if (genLikes[i] > maxLikes)
                {
                    maxLikes = (int)genLikes[i];    // updates the max likes
                    vidIndex = i;       // updates the index
                }
            }
            // outputs the most liked input as well as which video #
            Console.WriteLine("\nMost Liked Video\nVideo #" + (vidIndex + 1) + "\t" + maxLikes.ToString("n0") + " likes");
        }
        // loop that calculates the video with the least likes and which # video it is as well as outputting the data
        public static void minLikes(int numVids, long[] genLikes)
        {
            // sets a lowest likes variable
            // creates variable equal to first value of parallel array
            long minLikes = (int)genLikes[0];
            int vidIndex = 0;

            // loops through the rest of the array
            for (int i = 1; i < numVids; i++)
            {
                // if current value is smaller than the current least liked video
                if (genLikes[i] < minLikes)
                {
                    minLikes = (int)genLikes[i];    // updates the min likes
                    vidIndex = i;       // updates the index
                }
            }
            // outputs the least liked input as well as which video #
            Console.WriteLine("\nLeast Liked Video\nVideo #" + (vidIndex + 1) + "\t" + minLikes.ToString("n0") + " likes");
        }
        // method that outputs statistics for each video based on user input
        public static void displayStats(long[] genViews,long[] genLikes, int numVids)
        {

            // outputs format/labels of data
            Console.WriteLine("VIEWS");
            Console.WriteLine("Video #\t\tViews\t\t\tLikes\t\t\tLike %");
            
            // outputs data using for loop
            for (int i = 0; i < numVids;i++)
            {
                Console.WriteLine("Video #" + (i + 1) + "\t" + genViews[i].ToString("n0") + "\t\t" + genLikes[i].ToString("n0") + "\t\t" + calculateLikePct(genLikes[i], genViews[i]).ToString("P")); 
            } 
        }
    }
}

