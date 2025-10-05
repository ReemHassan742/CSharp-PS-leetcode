public class Solution {
    private int rows;
    private int cols;
    private int[][] islandHeights;
    
    private readonly int[][] directions = new int[][] {
        new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}  //(North, South, East, West) within the grid
    }; 

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        if (heights == null || heights.Length == 0) return new List<IList<int>>();

        islandHeights = heights;
        rows = heights.Length;
        cols = heights[0].Length;

        bool[,] pacificReachable = new bool[rows, cols];
        bool[,] atlanticReachable = new bool[rows, cols];

        for (int r = 0; r < rows; r++) {
            DFS(r, 0, pacificReachable);         
            DFS(r, cols - 1, atlanticReachable); 
        }
        for (int c = 0; c < cols; c++) {
            DFS(0, c, pacificReachable);        
            DFS(rows - 1, c, atlanticReachable); 
        }
        
        IList<IList<int>> result = new List<IList<int>>();
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (pacificReachable[r, c] && atlanticReachable[r, c]) {
                    result.Add(new List<int> { r, c });
                }
            }
        }

        return result;
    }

    private void DFS(int r, int c, bool[,] reachable) {
        if (reachable[r, c]) return;
        
        reachable[r, c] = true;

        foreach (var dir in directions) {
            int nextR = r + dir[0];
            int nextC = c + dir[1];

            if (nextR < 0 || nextR >= rows || nextC < 0 || nextC >= cols) {
                continue;
            }
            
            if (islandHeights[nextR][nextC] >= islandHeights[r][c]) {
                DFS(nextR, nextC, reachable);
            }
        }
    }
}