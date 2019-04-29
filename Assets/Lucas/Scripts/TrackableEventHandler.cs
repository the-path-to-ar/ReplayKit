using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TrackableEventHandler : DefaultTrackableEventHandler
{
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>(true);
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        videoPlayer.enabled = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        videoPlayer.enabled = false;
    }

}
