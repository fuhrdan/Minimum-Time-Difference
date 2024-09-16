//*****************************************************************************
//** 539. Minimum Time Difference   leetcode                                 **
//*****************************************************************************


int findMinDifference(char** timePoints, int timePointsSize) {
    if (timePointsSize < 2) return 0;
    
    int convertedHours[1440] = {0};  // Array to store occurrences of time in minutes
    int minTime = INT_MAX;
    int maxTime = INT_MIN;
    int prevTime = -1;
    int minDiff = INT_MAX;
    
    // Convert time points to minutes and store occurrences
    for (int i = 0; i < timePointsSize; i++) {
        int hour = ((timePoints[i][0] - '0') * 10) + (timePoints[i][1] - '0');
        int minute = ((timePoints[i][3] - '0') * 10) + (timePoints[i][4] - '0');
        int totalMinutes = (hour * 60) + minute;
        
        // If the same time point exists more than once, return 0
        if (convertedHours[totalMinutes] > 0) {
            return 0;
        }
        convertedHours[totalMinutes] = 1;
        
        // Track the minimum and maximum time in minutes
        if (totalMinutes < minTime) minTime = totalMinutes;
        if (totalMinutes > maxTime) maxTime = totalMinutes;
    }
    
    // Traverse through the array and find the smallest difference between consecutive times
    for (int i = 0; i < 1440; i++) {
        if (convertedHours[i] == 1) {
            if (prevTime != -1) {
                minDiff = (i - prevTime < minDiff) ? i - prevTime : minDiff;
            }
            prevTime = i;
        }
    }
    
    // Check the circular difference (from the last time back to the first time)
    int circularDiff = (1440 - maxTime + minTime);
    minDiff = (circularDiff < minDiff) ? circularDiff : minDiff;
    
    return minDiff;
}