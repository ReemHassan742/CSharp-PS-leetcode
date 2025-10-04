public class Solution {
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1;
        int container = 0;
        while (left < right){
            if(height[left] < height[right]){
                container = Math.Max((right - left) * height[left], container);
                ++left;

            } else {
               container = Math.Max((right - left) * height[right], container);
               --right;

            }

        }
        return container;
    }
}