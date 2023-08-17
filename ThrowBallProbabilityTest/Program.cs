
Random random = new Random();

bool test() {
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
    return (box1 == 2 && box2 == 5 && box3 == 3);
}

int passed = 0;
for  (int i = 0; i < 100000; i++) {
    if (test()) passed++;
}

Console.WriteLine(passed / 100000d);