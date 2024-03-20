from PIL import Image, ImageDraw

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
       

resize("1.jpg")
img.show()
img.save("2.jpg")