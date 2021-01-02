import matplotlib.pyplot as plt

test1 = "./binary.txt"
test2 = "./brute_force.txt"
test3 = "./segments.txt"


x1 = [196, 361, 841, 3481, 9801]
y1 = [147.9786, 160.6214, 182.0679, 247.764, 360.741]
y2 = [220.9459, 228.9209, 263.51, 353.1174, 468.3797]
y3 = [316.7127, 377.8083, 411.0667, 544.8644, 676.9156]

y11 = [0.532653836673985,  0.529975035227703, 0.504772141069258, 0.433753157996861, 0.339702786059739]
y12 = [0.530552709588415, 0.52310066679112, 0.517489458695486, 0.463973915564169, 0.379188094862668]
y13 = [0.520955732916696, 0.513174322962571, 0.516383056358949, 0.492774439710808, 0.425111398591772]

'''
with open(test1, mode="r") as f:
    for line in f:
        line = list(map(int, line.strip().split()))
        x1.append(line[0])
        y1.append(line[1])

with open(test2, mode="r") as f:
    for line in f:
        line = list(map(int, line.strip().split()))
        y2.append(line[1])

with open(test3, mode="r") as f:
    for line in f:
        line = list(map(int, line.strip().split()))
        y3.append(line[1])
'''
x2 = []
y4 = []
y5 = []
y6 = []

fig = plt.figure()

label1 = "250x250"
label2 = "300x300"
label3 = "400x400"

plt.plot(x1, y1, '.', color="red")
plt.plot(x1, y2, '.',color="red")
plt.plot(x1, y3, '.',color="red")
plt.plot(x1, y1, color="red", label=label1)
plt.plot(x1, y2, color="blue", label=label2)
plt.plot(x1, y3, color="yellow", label=label3)

plt.legend()

plt.title("Результаты эксперимента")
plt.xlabel("Количество полигонов")
plt.ylabel("Миллисекунды")
plt.grid(True)

plt.show()
legend.show()