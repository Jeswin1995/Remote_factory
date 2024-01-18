using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ThinkSpeakExample : MonoBehaviour
{
    public int CHANNEL_ID;
    public string apiKey;
    public int results;
    private string x;

    void Start()
    {
        // Replace YOUR_API_KEY with your actual ThingSpeak API key
        //string apiKey = "YOUR_API_KEY";

        // Replace CHANNEL_ID with the ID of the ThingSpeak channel you want to access
        int channelId = CHANNEL_ID;

        // Set up the URL for the request
        string url = "https://api.thingspeak.com/channels/" + channelId + "/feeds.json?api_key=" + apiKey + "&results=" + results;

        // Create a new UnityWebRequest
        UnityWebRequest request = UnityWebRequest.Get(url);

        // Send the request and wait for the response
        UnityWebRequestAsyncOperation operation = request.SendWebRequest();
        operation.completed += ProcessResponse;
    }

    void ProcessResponse(AsyncOperation operation)
    {
        // Get the UnityWebRequestAsyncOperation instance
        UnityWebRequestAsyncOperation requestOperation = (UnityWebRequestAsyncOperation)operation;

        // Check for errors
        if (requestOperation.webRequest.isHttpError || requestOperation.webRequest.isNetworkError)
        {
            Debug.LogError("Request error: " + requestOperation.webRequest.error);
            return;
        }

        // Get the response text
        string jsonData = requestOperation.webRequest.downloadHandler.text;
        Debug.Log(jsonData);
        ThingSpeakData data = JsonConvert.DeserializeObject<ThingSpeakData>(jsonData, 
        new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore // to ignore null values
        });

        // Check if the feeds property is not null
        if (data.feeds != null)
        {
            // Iterate over the feeds
            string[] fieldValues = { "No", "No", "No", "No", "No" };
            foreach (ThingSpeakFeed feed in data.feeds)
            {
                
                if(feed.field1 != null)
                {
                    fieldValues[0] = feed.field1;
                }

                if (feed.field2 != null)
                {
                    fieldValues[1] = feed.field2;
                }

                if (feed.field3 != null)
                {
                    fieldValues[2] = feed.field3;
                }
                
                if (feed.field4 != null)
                {
                    fieldValues[3] = feed.field4;
                }
                
                if (feed.field5 != null)
                {
                    fieldValues[4] = feed.field5;
                }

            }
            Debug.Log(fieldValues[0]);
            Debug.Log(fieldValues[1]);
            Debug.Log(fieldValues[2]);
            Debug.Log(fieldValues[3]);
            Debug.Log(fieldValues[4]);

            // Print the latest non-zero value
            //Debug.Log("Latest non-zero value: " + field1Value);
        }
    }
}
//Define a public class to hold the data
public class ThingSpeakData
{
    public ThingSpeakFeed[] feeds;
}

public class ThingSpeakFeed
{
    //public int field1 = 0;
    public string field1;
    public string field2;
    public string field3;
    public string field4;
    public string field5;
    // Other fields as needed
}



