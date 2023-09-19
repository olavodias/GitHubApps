// *****************************************************************************
// Program.cs
//
// Author:
//       Olavo Henrique Dias <olavodias@gmail.com>
//
// Copyright (c) 2023 Olavo Henrique Dias
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// *****************************************************************************

#pragma warning disable CS8602 // Dereference of a possibly null reference.

using System.Text;
using GitHubApps.EventMap;
using GitHubApps.Models.Events;

Dictionary<string, MapEvent> eventsDictionary = new();

Console.WriteLine("Generating Event Maps...");
PopulateData();

/*DisplayEvents(eventsDictionary[GitHubEvents.EVENT_INSTALLATION],
              eventsDictionary[GitHubEvents.EVENT_ISSUE_COMMENT],
              eventsDictionary[GitHubEvents.EVENT_ISSUES],
              eventsDictionary[GitHubEvents.EVENT_LABEL],
              eventsDictionary[GitHubEvents.EVENT_PULL_REQUEST],
              eventsDictionary[GitHubEvents.EVENT_PULL_REQUEST_REVIEW_COMMENT],
              eventsDictionary[GitHubEvents.EVENT_PULL_REQUEST_REVIEW],
              eventsDictionary[GitHubEvents.EVENT_PULL_REQUEST_REVIEW_THREAD],
              eventsDictionary[GitHubEvents.EVENT_PUSH],
              eventsDictionary[GitHubEvents.EVENT_RELEASE]);*/

DisplayEvents(eventsDictionary[GitHubEvents.EVENT_REPOSITORY]);

Console.WriteLine("Event Maps Generated");


static void DisplayEvents(params MapEvent[] mapEvents)
{
    List<string> eventAndActionList = new();
    List<string> parametersList = new();
    int maxColumnSize = 6;
    
    // Creates a list with all parameters of all events being compared
    foreach (var mapEvent in mapEvents)
    {
        if (mapEvent.Name.Length > maxColumnSize)
            maxColumnSize = mapEvent.Name.Length;

        if (mapEvent.Actions is not null)
        {
            // Event contains actions
            foreach (var mapAction in mapEvent.Actions)
            {
                var eventAndActionItem = $"{mapEvent.Name}:{mapAction.ActionName}";
                if (!eventAndActionList.Contains(eventAndActionItem))
                    eventAndActionList.Add(eventAndActionItem);

                if (mapAction.ActionName.Length > maxColumnSize)
                    maxColumnSize = mapAction.ActionName.Length;

                foreach (var mapActionParameter in mapAction.Parameters)
                {
                    if (!parametersList.Contains(mapActionParameter))
                    {
                        parametersList.Add(mapActionParameter);
                        if (mapActionParameter.Length > maxColumnSize)
                            maxColumnSize = mapActionParameter.Length;
                    }

                }
            }
        }
        else
        {
            // Event does not contain any action
            eventAndActionList.Add(mapEvent.Name);
        }
    }

    // Sort Parameters List
    parametersList.Sort();


    // Initialize the char array
    //   1st dimension = Event:Action (installation:created, installation:deleted, issues:created, pull_request, etc...)
    //   2nd dimension = Parameters
    string[,] dataArray = new string[eventAndActionList.Count+1, parametersList.Count+2];

    // Populate very first item of the array
    int iMapEventActionIndex = 0;

    dataArray[iMapEventActionIndex, 0] = "Event";
    dataArray[iMapEventActionIndex, 1] = "Action";

    for (int i = 0; i < parametersList.Count; i++)
    {
        dataArray[iMapEventActionIndex, i+2] = parametersList[i];        
    }
    iMapEventActionIndex++;

    // Populate arrays
    for (int iMapEvent = 0; iMapEvent < mapEvents.Length; iMapEvent++)
    {
        if (mapEvents[iMapEvent].Actions is not null)
        {
            // Event contains actions
            for (int iMapAction = 0; iMapAction < mapEvents[iMapEvent].Actions.Length; iMapAction++)
            {
                // Print event in header
                dataArray[iMapEventActionIndex, 0] = mapEvents[iMapEvent].Name;

                // Print action in header
                dataArray[iMapEventActionIndex, 1] = mapEvents[iMapEvent].Actions[iMapAction].ActionName;

                // Sort Parameters
                mapEvents[iMapEvent].Actions[iMapAction].SortParameters();

                int iParameterWrite = 0;
                for (int iParameterRead = 0; iParameterRead < mapEvents[iMapEvent].Actions[iMapAction].Parameters.Length; iParameterRead++)
                {
                    var currentParameter = mapEvents[iMapEvent].Actions[iMapAction].Parameters[iParameterRead];

                    while(iParameterWrite < parametersList.Count)
                    {
                        if (currentParameter == dataArray[0, iParameterWrite+2])
                        {
                            // Parameter matches, move on
                            dataArray[iMapEventActionIndex, iParameterWrite+2] = currentParameter;
                            iParameterWrite++;
                            break;
                        }
                        else
                        {
                            // Parameter does not match, try next slot
                            iParameterWrite++;
                        }
                    }
                }

                iMapEventActionIndex++;
            }
        }
        else
        {
            // Event does not contain any action
            // Print event in header
            dataArray[iMapEventActionIndex, 0] = mapEvents[iMapEvent].Name;

            // Increment array position
            iMapEventActionIndex++;
        }    
    }


    // Save to Text File
    File.WriteAllText("events.txt", GenerateTextFromArray(dataArray, maxColumnSize));

    // Save to CSV File
    File.WriteAllText("events.csv", GenerateCSVFromArray(dataArray, maxColumnSize));

}

static string GenerateTextFromArray(string[,] dataArray, int maxColumnSize)
{
    StringBuilder sbData = new((maxColumnSize+3) * dataArray.GetLength(0) + 2);

    for (int iRow = 0; iRow < dataArray.GetLength(1); iRow++)
    {
        for (int iColumn = 0; iColumn < dataArray.GetLength(0); iColumn++)
        {
            var dataToPrint = dataArray[iColumn, iRow] ?? string.Empty;
            sbData.Append("| ");
            sbData.Append(dataToPrint.PadRight(maxColumnSize, ' ')[..maxColumnSize]);
            sbData.Append(' ');
        }
        sbData.AppendLine("|");

        if (iRow == 1)
        {
            // Print the separator
            for (int iColumn = 0; iColumn < dataArray.GetLength(0); iColumn++)
            {
                sbData.Append("| ");
                sbData.Append(string.Empty.PadRight(maxColumnSize, '-')[..maxColumnSize]);
                sbData.Append(' ');
            }
            sbData.AppendLine("|");
        }
    }
    return sbData.ToString();
}

static string GenerateCSVFromArray(string[,] dataArray, int maxColumnSize)
{
    StringBuilder sbData = new((maxColumnSize + 3) * dataArray.GetLength(0) + 2);

    for (int iRow = 0; iRow < dataArray.GetLength(1); iRow++)
    {
        for (int iColumn = 0; iColumn < dataArray.GetLength(0); iColumn++)
        {
            var dataToPrint = dataArray[iColumn, iRow] ?? string.Empty;
            if (iColumn > 0) sbData.Append(',');

            sbData.Append('\"');
            sbData.Append(dataToPrint);
            sbData.Append('\"');

        }
        sbData.AppendLine();
    }
    return sbData.ToString();
}


void PopulateData()
{

    #region Installation Event

    eventsDictionary.Add(GitHubEvents.EVENT_INSTALLATION, new MapEvent(GitHubEvents.EVENT_INSTALLATION)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "enterprise", "installation", "organization", "repositories", "repository","requester", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "enterprise", "installation", "organization", "repositories", "repository","requester", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_NEW_PERMISSIONS_ACCEPTED,
              "action", "enterprise", "installation", "organization", "repositories", "repository","requester", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_SUSPEND,
              "action", "enterprise", "installation", "organization", "repositories", "repository","requester", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNSUSPEND,
              "action", "enterprise", "installation", "organization", "repositories", "repository","requester", "sender"),
        }
    });

    #endregion Installation Event

    #region Issues Event

    eventsDictionary.Add(GitHubEvents.EVENT_ISSUES, new MapEvent(GitHubEvents.EVENT_ISSUES)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_ASSIGNED,
              "action", "assignee", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_CLOSED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DEMILESTONED,
              "action", "enterprise", "installation", "issue", "milestone", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "issue", "label", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_LABELED,
              "action", "enterprise", "installation", "issue", "label", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_LOCKED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_MILESTONED,
              "action", "enterprise", "installation", "issue", "milestone", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_OPENED,
              "action", "changes", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_PINNED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_REOPENED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_TRANSFERRED,
              "action", "changes", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNASSIGNED,
              "action", "assignee", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNLABELED,
              "action", "enterprise", "installation", "issue", "label", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNLOCKED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNPINNED,
              "action", "enterprise", "installation", "issue", "organization", "repository", "sender"),
        }
    });

    #endregion Issues Event

    #region Issue Comment Event

    eventsDictionary.Add(GitHubEvents.EVENT_ISSUE_COMMENT, new MapEvent(GitHubEvents.EVENT_ISSUE_COMMENT)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "comment", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "comment", "enterprise", "installation", "issue", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "comment", "enterprise", "installation", "issue", "organization", "repository", "sender"),
        }
    });

    #endregion Issue Comment Event

    #region Label Event

    eventsDictionary.Add(GitHubEvents.EVENT_LABEL, new MapEvent(GitHubEvents.EVENT_LABEL)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "enterprise", "installation", "label", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "enterprise", "installation", "label", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "label", "organization", "repository", "sender"),
        }
    });

    #endregion Label Event

    #region Pull-Request Event

    eventsDictionary.Add(GitHubEvents.EVENT_PULL_REQUEST, new MapEvent(GitHubEvents.EVENT_PULL_REQUEST)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_ASSIGNED,
              "action", "assignee", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_AUTO_MERGE_DISABLED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "reason", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_AUTO_MERGE_ENABLED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "reason", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_CLOSED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DEMILESTONED,
              "action", "enterprise", "milestone", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DEQUEUED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "reason", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_ENQUEUED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_LABELED,
              "action", "enterprise", "installation", "label", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_LOCKED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_MILESTONED,
              "action", "enterprise", "milestone", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_OPENED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_REOPENED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_REVIEW_REQUEST_REMOVED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "requested_reviewer", "sender", "requested_team"),
            new MapAction(GitHubEventActions.EVENT_ACTION_REVIEW_REQUESTED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "requested_reviewer", "sender", "requested_team"),
            new MapAction(GitHubEventActions.EVENT_ACTION_SYNCHRONIZE,
              "action", "after", "before", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNASSIGNED,
              "action", "assignee", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNLABELED,
              "action", "enterprise", "installation", "label", "number", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNLOCKED,
              "action", "enterprise", "installation", "number", "organization", "pull_request", "repository", "sender"),
        }
    });

    #endregion Pull-Request Event

    #region Pull-Request-Review-Comment Event

    eventsDictionary.Add(GitHubEvents.EVENT_PULL_REQUEST_REVIEW_COMMENT, new MapEvent(GitHubEvents.EVENT_PULL_REQUEST_REVIEW_COMMENT)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "comment", "enterprise", "installation", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "comment", "enterprise", "installation", "organization", "pull_request", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "comment", "enterprise", "installation", "organization", "pull_request", "repository", "sender"),
        }
    });

    #endregion Pull-Request-Review-Comment Event

    #region Pull-Request-Review Event

    eventsDictionary.Add(GitHubEvents.EVENT_PULL_REQUEST_REVIEW, new MapEvent(GitHubEvents.EVENT_PULL_REQUEST_REVIEW)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_DISMISSED,
              "action", "enterprise", "installation", "organization", "pull_request", "repository", "review", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_SUBMITTED,
              "action", "enterprise", "installation", "organization", "pull_request", "repository", "review", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "organization", "pull_request", "repository", "review", "sender"),
        }
    });

    #endregion Pull-Request-Review Event

    #region Pull-Request-Review-Thread Event

    eventsDictionary.Add(GitHubEvents.EVENT_PULL_REQUEST_REVIEW_THREAD, new MapEvent(GitHubEvents.EVENT_PULL_REQUEST_REVIEW_THREAD)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_RESOLVED,
              "action", "enterprise", "installation", "organization", "pull_request", "repository", "sender", "thread"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNRESOLVED,
              "action", "enterprise", "installation", "organization", "pull_request", "repository", "sender", "thread"),
        }
    });

    #endregion Pull-Request-Review-Thread Event

    #region Push Event

    eventsDictionary.Add(GitHubEvents.EVENT_PUSH, new MapEvent(GitHubEvents.EVENT_PUSH)
    {
        Actions = new MapAction[]
        {
            new MapAction(string.Empty,
              "after", "base_ref", "before", "commits", "compare", "created", "deleted", "enterprise", "forced", "head_commit", "installation", "organization", "pusher", "ref", "repository", "sender"),
        }
    });

    #endregion Push Event

    #region Release Event

    eventsDictionary.Add(GitHubEvents.EVENT_RELEASE, new MapEvent(GitHubEvents.EVENT_RELEASE)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_PRERELEASED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_PUBLISHED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_RELEASED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNPUBLISHED,
              "action", "enterprise", "installation", "organization", "release", "repository", "sender"),
        }
    });

    #endregion Release Event

    #region Repository Event

    eventsDictionary.Add(GitHubEvents.EVENT_REPOSITORY, new MapEvent(GitHubEvents.EVENT_REPOSITORY)
    {
        Actions = new MapAction[]
        {
            new MapAction(GitHubEventActions.EVENT_ACTION_ARCHIVED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_CREATED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_DELETED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_EDITED,
              "action", "changes", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_PRIVATIZED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_PUBLICIZED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_RENAMED,
              "action", "changes", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_TRANSFERRED,
              "action", "changes", "enterprise", "installation", "organization", "repository", "sender"),
            new MapAction(GitHubEventActions.EVENT_ACTION_UNARCHIVED,
              "action", "enterprise", "installation", "organization", "repository", "sender"),
        }
    });

    #endregion Repository Event
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.
