# $@ = target file
# $< = first dependency
# $^ = all dependencies

all: disk.bin

bin/boot.bin: src/boot.asm
	nasm $< -f bin -o $@

bin/prog.bin: src/prog.asm
	nasm $< -f bin -o $@

disk.bin: bin/boot.bin bin/prog.bin
	dd if=/dev/zero of=disk.bin bs=1024 count=10
	dd if=bin/boot.bin of=disk.bin bs=512 count=1 conv=notrunc,fsync
	dd if=bin/prog.bin of=disk.bin bs=512 count=16 seek=1 conv=notrunc,fsync

run: clean disk.bin
	qemu-system-i386 -hda disk.bin -monitor stdio

clean:
	rm -rf *.bin bin/*.bin