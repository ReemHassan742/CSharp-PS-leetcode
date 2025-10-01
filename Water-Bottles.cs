public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int total = numBottles;  
        int emptyBottles = numBottles;
        
        while (emptyBottles >= numExchange) {
            int newBottles = emptyBottles / numExchange;  
            total += newBottles;                          
            emptyBottles = emptyBottles % numExchange + newBottles; 
        }
        
        return total;
    }
}
