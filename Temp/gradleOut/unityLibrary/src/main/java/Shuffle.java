import java.util.*;
public class Shuffle{
    public static void main(String []args){
        Scanner sc = new Scanner(System.in);
        // capture first interger values
        // iterate though 
        int num = -1;
        while (num != 0){
            num = Integer.parseInt(sc.nextLine());
            String []list = new String[num];
            for (int i = 0; i < num; i++){
                list[i] = sc.nextLine();
            }
            int start = 0;
            int mid = 0;
            int ptr2 = mid;
            if (num % 2 == 0){
                mid = num / 2;
            }
            else{
                mid = (num / 2) + 1;
            }
            while (mid > start){
                System.out.println(list[start]);
                if (num > ptr2){
                    System.out.println(list[ptr2]);
                }
                ptr2++;
                start++;
            }
        }
        

    }
}