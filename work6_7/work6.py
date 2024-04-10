from PIL import Image, ImageDraw
import numpy as np
import time

def open_img(path):
    global image, pix, draw, width, height, size
    image = Image.open(path)
    pix = image.load()
    draw =  ImageDraw.Draw(image)
    width = image.size[0]
    height = image.size[1]
    size = min(image.size[0], image.size[1])

def new_img():
    global img, draw_img
    img = Image.new(mode="RGB", size=(width * 2, height * 2))
    draw_img = ImageDraw.Draw(img)


def resize(path):
    open_img(path)
    new_img()
    
    for i in range(size):
        for j in range(size):
            r = pix[i, j][0]
            g = pix[i, j][1]
            b = pix[i, j][2]
        
            if (i != 0 and j != 0) and (i != size - 1 and j != size - 1):
                r12 = (r + pix[i, j + 1][0]) // 2
                g12 = (g + pix[i, j + 1][1]) // 2
                b12 = (b + pix[i, j + 1][2]) // 2            

                r21 = (r + pix[i + 1, j][0]) // 2
                g21 = (g + pix[i + 1, j][1]) // 2
                b21 = (b + pix[i + 1, j][2]) // 2
            
                r22 = (r + pix[i + 1, j + 1][0]) // 2
                g22 = (g + pix[i + 1, j + 1][1]) // 2
                b22 = (b + pix[i + 1, j + 1][2]) // 2
            
                draw_img.point((i * 2, j * 2), (r, g, b))                 # 11
                draw_img.point((i * 2 + 1, j * 2), (r, g, b))             # 12
                draw_img.point((i * 2, j * 2 + 1), (r21, g21, b21))       # 21
                draw_img.point((i * 2 + 1, j * 2 + 1), (r, g, b))         # 22
            else:
                draw_img.point((i * 2, j * 2), (r, g, b))
                draw_img.point((i * 2 + 1, j * 2), (r, g, b))
                draw_img.point((i * 2, j * 2 + 1), (r, g, b))
                draw_img.point((i * 2 + 1, j * 2 + 1), (r, g, b))
                
def downscale1(path, scale):
    start_time = time.time()
    
    open_img(path)
    #global img
    img = Image.new(mode="RGB", size=(int(width * scale), int(height * scale)))
    draw_img = ImageDraw.Draw(img)

    size = image.height
    box_size = int(np.ceil(1 / scale))
    image_arr = np.array(image)
    for y in range(size):
        for x in range(size):
            x_ = int(np.floor(x / scale))
            y_ = int(np.floor(y / scale))
            
            x_end = min(x_ + box_size, size - 1)
            y_end = min(y_ + box_size, size - 1)
            
            pixel = image_arr[y_:y_end, x_:x_end].mean(axis=(0,1))
            
            pixel = np.round(pixel)
            pixel = tuple(pixel.astype(int))
            
            draw_img.point((x, y), pixel)
            
    print("Time: ", (time.time() - start_time))
    img.save("2.jpg")
    

def downscale2(path, scale):
    open_img(path)
    
    img = Image.new(mode="RGB", size=(int(width * scale), int(height * scale)))
    draw_img = ImageDraw.Draw(img)
    
    size = image.height
    start_time = time.time()
    for i in range(1, size - 1, 2):
        for j in range(1, size - 1, 2):
            r11 = pix[i, j][0]
            g11 = pix[i, j][1]
            b11 = pix[i, j][2]
            
            r12 = pix[i, j + 1][0]
            g12 = pix[i, j + 1][1]
            b12 = pix[i, j + 1][2]
            
            r21 = pix[i + 1, j][0]
            g21 = pix[i + 1, j][1]
            b21 = pix[i + 1, j][2]
            
            r22 = pix[i + 1, j + 1][0]
            g22 = pix[i + 1, j + 1][1]
            b22 = pix[i + 1, j + 1][2]
            
            r = int((r11 + r12 + r21 + r22) / 4)
            g = int((g11 + g12 + g21 + g22) / 4)
            b = int((b11 + b12 + b21 + b22) / 4)
            
            draw_img.point((i // 2, j // 2), (r, g, b))
    
    print("Time: ", (time.time() - start_time))
    img.save("3.jpg")


downscale2("1.jpg", 0.5)
# img.show()
# img.save("2.jpg")