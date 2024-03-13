# -*- coding: cp1251 -*-
import random
from PIL import Image, ImageDraw              
    

def open_img(path):
    global image, pix, draw, width, height, size
    image = Image.open(path)
    pix = image.load()
    draw =  ImageDraw.Draw(image)
    width = image.size[0]
    height = image.size[1]
    size = min(image.size[0], image.size[1])

open_img("1.jpg")

# crop and use new
image.crop((0, 0, size, size)).save("2.jpg")


# functions
def rotate():
    open_img("2.jpg")
    for i in range(size):
        for j in range(size):
            if (i < j):
                r = pix[i, j][0]
                g = pix[i, j][1]
                b = pix[i, j][2]
        
                r_t = pix[j, i][0]
                g_t = pix[j, i][1]
                b_t = pix[j, i][2]
        
                draw.point((j, i), (r, g, b))
                draw.point((i, j), (r_t, g_t, b_t))
    image.save("rotated.jpg")
    
def gray():
    open_img("2.jpg")
    for i in range(size):
        for j in range(size):
            r = pix[i, j][0]
            g = pix[i, j][1]
            b = pix[i, j][2]
        
            S = (r + g + b) // 3
            draw.point((i, j), (S, S, S))   
    image.save("gray.jpg")

def sepia():
    open_img("2.jpg")
    k = int(input("Input level: "))
    for i in range(size):
        for j in range(size):
            r = pix[i, j][0]
            g = pix[i, j][1]
            b = pix[i, j][2]
            gr = (r + g + b) // 3

            r += k * 2
            g += k
            if r > 255:
                r = 255
            if g > 255:
                g = 255
            draw.point((i, j), (r, g, b))  
    image.save("sepia.jpg")
    

# using functions
rotate()
gray()
sepia()