
Random random = new Random();

(bool, bool) test() {
    int box1 = 0, box2 = 0, box3 = 0;
    for (int i = 0; i < 10; i++) {
        int int_random = random.Next(0, 4);
        switch (int_random) {
            case 0:
                box1++;
                break;
            case 1 or 2:
                box2++;
                break;
            case 3:
                box3++;
                break;
        }
    }
    return (box1 == 2 && box2 == 5 && box3 == 3, box1 == 0);
}

int passed_a = 0;
int passed_b = 0;
int totalCount = 1000000;
for  (int i = 0; i < totalCount; i++) {
    (bool a ,bool b) = test();
    if (a) passed_a++;
    if (b) passed_b++;
}

Console.WriteLine("Probability of box 1 has 2 balls, box 2 has 5 balls, and box 3 has 3 balls: " +  passed_a / (double)totalCount);
Console.WriteLine("Probability of box 1 has 0 balls: " +  passed_b / (double)totalCount);

