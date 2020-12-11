import java.util.Scanner;
import java.util.*;

public class lab_10 {
    public static void main(String[] args) {
        String encoding = System.getProperty("console.encoding", "cp866"), name1, num1, nameLek1, mass1, f;
        Scanner in = new Scanner(System.in, encoding);
        Apteka[] apteka = new Apteka[10];
        Lek[] lek = new Lek[10];
        Number k = new Number();
        int numOfMeds1, amount1, i, max, n;
        double price1;
        System.out.println("Ввести данные через read или init(1 - read, 2 - init)");
        f = in.nextLine();
        if(f.equals("1")){
            apteka[0] = new Apteka();
            apteka[0].read();
        }
        else{
            System.out.println("Ввести все параметры (1), ввести только название (2), не вводить параметры (3)");
            f = in.nextLine();
            if(f.equals("1")){
                System.out.println("Введите название аптеки");
                name1 = in.nextLine();
                System.out.println("Введите номер аптеки");
                adress1 = in.nextLine();
                System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
                f = in.nextLine();
                i = 0;
                while(f.equals("1")){
                    System.out.println("Введите название лекарства");
                    nameLek1 = in.nextLine();
                    System.out.println("Введите код лекарства");
                    mass1 = in.nextLine();
                    try{
                        System.out.println("Введите цену");
                        price1 = in.nextDouble();
                    }
                    catch(Exception e){
                        price1 = 0;
                        in.nextLine();
                    }
                    try{
                        System.out.println("Введите колличество");
                        amount1 = in.nextInt();
                    }
                    catch(Exception e){
                        amount1 = 0;
                    }
                    in.nextLine();
                    lek[i] = new Lek(mass1, nameLek1, price1, amount1);
                    i++;
                    System.out.println("Добавить лекарство ?(1 - да, 0 - нет)");
                    f = in.nextLine();
					if (f == "0") {
						break;
					}
                }
                numOfMeds1 = i;
                apteka[0] = new Apteka(name1, num1, numOfMeds1, lek);
            }
            else if(f.equals("2")){
                System.out.println("Введите название аптеки");
                name1 = in.nextLine();
                apteka[0] = new Apteka(name1);
            }
            else{
                apteka[0] = new Apteka();
            }
        }
        f = "0";
        i = 0;
        max = 1;
        while(f.equals("9") == false){
            System.out.println("Введите номер следующего действия");
            System.out.println("1 - показать информацию о аптеки");
            System.out.println("2 - добавить новое лекарство");
            System.out.println("3 - изменить цену лекарства");
            System.out.println("4 - добавить аптеку");
            System.out.println("5 - показать все аптеки");
            System.out.println("6 - сменить аптеки");
            System.out.println("7 - показать колличество лекарств");
            System.out.println("8 - изменить колличество мест для лекарств в аптеки");
            System.out.println("9 - выйти");
            f = in.nextLine();
            if(f.equals("1")){
                apteka[i].display();
            }
            else if(f.equals("2")){
                apteka[i].add();
            }
            else if(f.equals("3")){
                System.out.println("Введите код лекарства");
                mass1 = in.nextLine();
                System.out.println("Введите новую цену");
                try{
                    price1 = in.nextDouble();
                }
                catch(Exception e){
                    price1 = 0;
                }
                in.nextLine();
                apteka[i].priceChange(mass1, price1);
            }
            else if(f.equals("4")){
                apteka[max] = new Apteka();
                apteka[max].read();
                i=max;
                max++;
            }
            else if(f.equals("5")){
                for(n = 0; n < max; n++){
                    apteka[n].displayName();
                }
            }
            else if(f.equals("6")){
                System.out.println("Введите название аптеки");
                name1 = in.nextLine();
                for(n = 0;n < max;n++){
                    if(apteka[n].aptekacmp(name1)){
                        i = n;
                        n = max;
                    }
                }
            }
            else if(f.equals("7")){
                apteka[i].getNumber(k);
                System.out.println(k.number);
            }
            else if(f.equals("8")){
                System.out.println("Введите колличество");
                numOfMeds1 = in.nextInt();
                Apteka.maxNumOfMedsChange(numOfMeds1);
                in.nextLine();
            }
        }    
    }
}
