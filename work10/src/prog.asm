[org 0x7E00]

    jmp start

struc Node
    .val:   resd 1
    .left:  resd 1
    .right: resd 1
endstruc

nodes:
    times 30 dd 0

visited:
    times 10 db 0

val: dd 0x00
stack: dd 0x7E00
search_val: dd 0x34


start:
    ; eax = node_0
    call createTree
    call DFSSearch
    jmp $


DFSSearch:
    push ebx
    sub dword [stack], 4
    mov ebx, [stack]
    mov [ebx], eax
    pop ebx

    xor ecx, ecx    ; stack count
    mov cx, 1
.while:
    ; while (stack.length > 0):
    cmp cx, 0
    jle .end

    push ebx
    mov ebx, [stack]
    add dword [stack], 4
    mov eax, [ebx]
    pop ebx
    dec cx

    mov ebx, [eax]
    mov dword [val], ebx

    ; Print all nodes
    ; push eax
    ; mov ah, 0x0e
    ; mov al, byte [val]
    ; int 0x10
    ; mov al, ' '
    ; int 0x10
    ; pop eax

    ; if (n.val == search_val)
    cmp ebx, [search_val]
    je .found

    mov ebx, visited
    sub ebx, 0x30
    add ebx, [val]
    mov byte [ebx], 1

    call if_left
    call if_right
    jmp .while
.end:
    ret
.found:
    call printNode
    ret

if_left:
    ; if (n.left != null && !visited.Contains(n.left))
    mov ebx, [eax + 4]
    cmp ebx, 0xFFFFFFFF
    je .not
    mov edx, [eax + 4]
    mov edx, [edx]
    sub edx, 0x30
    mov ebx, visited
    add ebx, edx
    cmp byte [ebx], 1
    je .not

    push ebx
    sub dword [stack], 4
    mov ebx, [stack]
    mov edx, dword [eax + 4]
    mov [ebx], edx
    pop ebx
    inc cx
.not:
    ret

if_right:
    ; if (n.right != null && !visited.Contains(n.right))
    mov ebx, [eax + 8]
    cmp ebx, 0xFFFFFFFF
    je .not
    mov edx, [eax + 8]
    mov edx, [edx]
    sub edx, 0x30
    mov ebx, visited
    add ebx, edx
    cmp byte [ebx], 1
    je .not

    push ebx
    sub dword [stack], 4
    mov ebx, [stack]
    mov edx, dword [eax + 8]
    mov [ebx], edx
    pop ebx
    inc cx
.not:
    ret


; Print all children of this node (n ~ Null)
printNode:
    mov word [0x7D00], 'n'
    mov ebx, [eax + 4]
    cmp ebx, 0xFFFFFFFF
    jne .next1
    mov ebx, 0x7D00
.next1:
    mov edx, [eax + 8]
    cmp edx, 0xFFFFFFFF
    jne .next2
    mov edx, 0x7D00
.next2:
    mov ah, 0x0e
    mov al, [ebx]
    int 0x10
    mov al, ' '
    int 0x10
    mov al, [edx]
    int 0x10

    ret


createTree:
    ; Node 9
    mov dword [nodes + 9 * Node_size + Node.val], '7'
    mov dword [nodes + 9 * Node_size + Node.left], 0xFFFFFFFF
    mov dword [nodes + 9 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 8
    mov dword [nodes + 8 * Node_size + Node.val], '8'
    mov dword [nodes + 8 * Node_size + Node.left], 0xFFFFFFFF
    mov dword [nodes + 8 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 7
    mov dword [nodes + 7 * Node_size + Node.val], '9'
    mov dword [nodes + 7 * Node_size + Node.left], 0xFFFFFFFF
    mov dword [nodes + 7 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 6
    mov dword [nodes + 6 * Node_size + Node.val], '6'
    mov dword [nodes + 6 * Node_size + Node.left], 0xFFFFFFFF
    mov dword [nodes + 6 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 5
    mov dword [nodes + 5 * Node_size + Node.val], '0'
    mov dword [nodes + 5 * Node_size + Node.left], 0xFFFFFFFF
    mov dword [nodes + 5 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 4
    mov dword [nodes + 4 * Node_size + Node.val], '1'
    mov dword [nodes + 4 * Node_size + Node.left], nodes + 9 * Node_size
    mov dword [nodes + 4 * Node_size + Node.right], 0xFFFFFFFF
    ; Node 3
    mov dword [nodes + 3 * Node_size + Node.val], '4'
    mov dword [nodes + 3 * Node_size + Node.left], nodes + 7 * Node_size
    mov dword [nodes + 3 * Node_size + Node.right], nodes + 8 * Node_size
    ; Node 2
    mov dword [nodes + 2 * Node_size + Node.val], '5'
    mov dword [nodes + 2 * Node_size + Node.left], nodes + 5 * Node_size
    mov dword [nodes + 2 * Node_size + Node.right], nodes + 6 * Node_size
    ; Node 1
    mov dword [nodes + 1 * Node_size + Node.val], '3'
    mov dword [nodes + 1 * Node_size + Node.left], nodes + 3 * Node_size
    mov dword [nodes + 1 * Node_size + Node.right], nodes + 4 * Node_size
    ; Node 0
    mov dword [nodes + 0 * Node_size + Node.val], '2'
    mov dword [nodes + 0 * Node_size + Node.left], nodes + 1 * Node_size
    mov dword [nodes + 0 * Node_size + Node.right], nodes + 2 * Node_size

    mov eax, nodes
    ret

times 8192 - ($ - $$) db 0x00
