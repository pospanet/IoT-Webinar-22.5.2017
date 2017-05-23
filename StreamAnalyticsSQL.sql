SELECT
    DeviceName,
    Min(Value) as Min,
    Max(Value) as Max,
    Avg(Value) as Avg,
    System.TimeStamp as Date
INTO
    output
FROM
    input TIMESTAMP by Date
GROUP BY
    TUMBLINGWINDOW ( second  , 20 ),
    DeviceName