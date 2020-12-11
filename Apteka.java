import java.util.Scanner;

public class Apteka {
    String name;
    String num;
    int numOfMeds;
    static int maxNumOfMeds = 10;
    Lek[] lek = new Lek[10];
    void read(){
        int f,i;
        String encoding = System.getProperty("console.encoding", "cp866");
        Scanner in = new Scanner(System.in, encoding);
        System.out.println("Введите название аптеки");
        name = in.nextLine();
        System.out.println("Введите номер аптеки");
        adress = in.nextLine();
        System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
        f = in.nextInt();
        i = 0;
        while(f == 1 && i < maxNumberOfItems){
            item[i] = new Item();
            item[i].read();
            i++;
           System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
            f = in.nextInt();
			if (f == 0) {
				break;
			}
        }
        numOfMeds = i;
    }
    Apteka(String name1, String num1, int numOfMeds1, Lek lek1[]){
        if(numOfMeds1 <= maxNumOfMeds){
            name = name1;
            num = num1;
           numOfMeds = numOfMeds1;
            for(numOfMeds1 = 0; numOfMeds1 < numOfMeds; numOfMeds1++){
                lek[numOfMeds1] = lek1[numOfMeds1];
            }
        }
    }
    Apteka(String name1){
        name = name1;
        num = "-";
        numOfMeds = 0;
    }
    Apteka(){
        name = "-";
        num = "-";
        numOfMeds = 0;
    }
    void display(){
        int i;
        System.out.println("Название аптеки: " + name);
        System.out.println("Номер аптеки: " + num);
        System.out.println("Колличество лекарств: " + numOfMeds);
        System.out.println("Колличество мест для лекарств: " + maxNumOfMeds);
        for(i = 0;i < numOfMeds; i++){
            System.out.println("Лекарство: " + (i+1));
            lek[i].display();
        }
    }
    void add(){
        if(numOfMeds < maxNumOfMeds){
            lek[numOfMeds] = new Lek();
            lek[numOfMeds].read();
            numOfMeds++;
        }
    }
    void priceChange(String mass, double price){
        int i = 0;
        while(i < numOfMeds){
            if(mass.equals(lek[i].getMass())){
                lek[i].setPrice(price);
                i = numOfMeds;
            }
            i++;
        }
    }
    void displayName(){
        System.out.println("Аптека: " + name);
    }
    boolean aptekacmp(String name1){
       if(name.equals(name1)){
           return true;
       }
       else {
           return false;
       }
    }
    void getNumber(Number k){
        k.number = numOfMeds;
    }
    static void maxNumOfMedsChange(int newMax){
        maxNumOfMeds = newMax;
    }
}
