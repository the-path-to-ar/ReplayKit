using SA.Foundation.Templates;
using SA.iOS.ReplayKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayHandle : MonoBehaviour
{
    public Button startButton;
    public Button stopButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = ISN_RPScreenRecorder.IsAvailable;
        stopButton.interactable = ISN_RPScreenRecorder.IsAvailable;

        startButton.onClick.AddListener(() => {
            ISN_RPScreenRecorder.IsMicrophoneEnabled = true;
            ISN_RPScreenRecorder.StartRecording(a => {
                StartRecordingEvent(a, () => {
                    stopButton.gameObject.SetActive(true);
                    startButton.gameObject.SetActive(false);
                }, b => {
                    print(b);
                });
            });
        });

        stopButton.onClick.AddListener(() => {
            ISN_RPScreenRecorder.StopRecordingExtend(a => {
                StopRecordingEvent(a, () => {
                    stopButton.gameObject.SetActive(false);
                    startButton.gameObject.SetActive(true);
                }, b => {
                    print(b);
                });
            });
        });
    }

    private void StartRecordingEvent(SA_Result callback, Action succeedAction = null, Action<string> failureAction = null)
    {
        if (!callback.IsSucceeded)
        {
            if (failureAction != null)
            {
                failureAction.Invoke(callback.Error.Message);
            }
        }
        else
        {
            if (succeedAction != null)
            {
                succeedAction.Invoke();
            }
        }
    }

    private void StopRecordingEvent(string callback, Action succeedAction = null, Action<string> failureAction = null)
    {
        if (!string.IsNullOrEmpty(callback))
        {
            if (failureAction != null)
            {
                failureAction.Invoke(callback);
            }
        }
        else
        {
            if (succeedAction != null)
            {
                succeedAction.Invoke();
            }
        }
    }
}
