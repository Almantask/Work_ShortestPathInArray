# Work_ShortestPathInArray
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/b036214c83c24a5daea9e89e2297d16f)](https://app.codacy.com/app/Almantask/Work_ShortestPathInArray?utm_source=github.com&utm_medium=referral&utm_content=Almantask/Work_ShortestPathInArray&utm_campaign=Badge_Grade_Dashboard)
[![Build Status](https://travis-ci.com/Almantask/Work_ShortestPathInArray.svg?branch=master)](https://travis-ci.com/Almantask/Work_ShortestPathInArray)

Determine if you can reach the last element for array according these rules:
1. You start at first element.
2. Current element value indicates how many steps you can take at most.
(Example: if the value is 3 you can take 0, 1, 2 or 3 steps).

Winnable example:
1 2 0 3 0 2 0

Not winnable example:
1 2 0 1 0 2 0


Part 1 (C#):
Write an API with an endpoint that would:
1. Accept array as input parameter
2. Determine if the goal is reachable
3. Provide most efficient path.
4. If the same array is passed two times,
only one calculation should be made.

Part 2 (React):
Create a user interface where user could:
1. Modify the array.
2. Receive feedback if the goal is reachable.
3. See most efficient path.
