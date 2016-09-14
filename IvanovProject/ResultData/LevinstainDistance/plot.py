import numpy
from os import listdir
import matplotlib.pyplot as plt

list_of_files = listdir(".")    # read all files in directory
my_txt_list = filter(lambda x: x.endswith('.txt'), list_of_files) # read only txt
for txt_file in my_txt_list:
    print (txt_file)
    txt_file_i = open(txt_file).readlines()
    N = len(txt_file_i) - 1
    x = [i for i in range(0,N)]
    y = [0 for i in range(0,N)]
    for i in range(0,N):
        y[i] = float(txt_file_i[i].rstrip())
    plt.title(u'Velocity Pouseuille flow profile')
    plt.xlabel(u'Chanal Id number')
    plt.ylabel(u'Velocity Vx module')
    plt.grid()
    plt.plot(x,y, 'ro-')    #plot(x,y, 'line_style')
    png_name = str(txt_file[:-4])
    plt.savefig(png_name + '.png', format = 'png')
    plt.clf()   # clear plot area
    
        
