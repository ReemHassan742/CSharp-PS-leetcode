public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int total = numBottles;
        int empty = numBottles;
        int exchangeRate = numExchange;
        
        while (empty >= exchangeRate) {
            empty -= exchangeRate;  
            total += 1;             
            empty += 1;            
            exchangeRate++;         
        }
        
        return total;
    }
}