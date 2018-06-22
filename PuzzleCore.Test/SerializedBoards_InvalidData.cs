using System;
using System.Collections;
using Xunit;

public class SerializedBoards_InvalidData : TheoryData<string>
{
    public SerializedBoards_InvalidData()
    {
        // More than one empty space
        Add(@"2, 2,
              0, 1,
              2, 0");
        Add(@"2, 2,
              0, 0,
              1, 0");
        Add(@"2, 2,
              0, 0,
              0, 0");

        // Missing/multiple tiles
        Add(@"2, 2,
              0, 1, 
              2, 2");
        Add(@"2, 2,
              0, 1, 
              1, 3");
        Add(@"2, 2,
              1, 3, 
              3, 1");

        //Missing/extra tiles
        Add(@"2, 2,
              0, 1, 
              2, 9");
        Add(@"2, 2,
              9, 8, 
              7, 9");
        Add(@"2, 2,
              9, 9,
              0, 0");
    }
}
