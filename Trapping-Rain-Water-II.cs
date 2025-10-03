public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        if (heightMap.Length < 3) return 0;
        
        int m = heightMap.Length, n = heightMap[0].Length, water = 0, max = 0;
        var heap = new PriorityQueue<(int, int, int), int>();
        var visited = new bool[m, n];
        
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (i == 0 || i == m-1 || j == 0 || j == n-1) {
                    heap.Enqueue((heightMap[i][j], i, j), heightMap[i][j]);
                    visited[i, j] = true;
                }
        
        while (heap.Count > 0) {
            var (h, i, j) = heap.Dequeue();
            max = Math.Max(max, h);
            foreach (var (dx, dy) in new[] {(1,0), (-1,0), (0,1), (0,-1)}) {
                int ni = i + dx, nj = j + dy;
                if (ni >= 0 && ni < m && nj >= 0 && nj < n && !visited[ni, nj]) {
                    visited[ni, nj] = true;
                    if (heightMap[ni][nj] < max) water += max - heightMap[ni][nj];
                    heap.Enqueue((heightMap[ni][nj], ni, nj), heightMap[ni][nj]);
                }
            }
        }
        return water;
    }
}