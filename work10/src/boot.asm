[bits 16]
[org 0x7C00]

    jmp start

start:
    mov [drive], dl

    mov dword [dap_block_count], 0x10
    mov dword [dap_segment], 0x0000
    mov dword [dap_offset], 0x7E00
    mov eax,  1
    mov [dap_sector_low], eax
    mov ah, 0x42
    mov dl, [drive]
    mov si, dap
    int 0x13

    jmp 0x0000:0x7E00


drive db 0x00

; Data Address Packet (DAP) for reading from disk using BIOS service int 13h/42h
dap:
dap_size:		    db 0x10		; Size of the data address packet.
dap_reserved:		db 0x00		; Reserved. Should be 0
dap_block_count:	dw 0x01		; Number of blocks to read
dap_offset:		    dw 0x0000	; Offset. (Already set with default)
dap_segment:		dw 0x00		; Segment
dap_sector_low:		dd 0x01		; Lower 32 bits of sector number
dap_sector_high:	dd 0x00		; Upper 32 bits of sector number

times 510 - ($ - $$) db 0x00
dw 0xAA55