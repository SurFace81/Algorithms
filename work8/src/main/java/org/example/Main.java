package org.example;

import java.text.DecimalFormat;
import java.text.NumberFormat;

public class Main {
    public static void main(String[] args) {
        String fullStr = "ahsgdh abcabc agdhsghd gadfghdfg sgdh abcabc fasdghagsdhj gasdkghsadgah jsgd abcabc kjhashdsagdk abcabc HASJdashl";
        String word = "abcabc";

        NumberFormat formatter = new DecimalFormat("#0.00000");
        long start = System.nanoTime();
        System.out.println(findWord(word, fullStr));
        System.out.println("Execution time is " + formatter.format((System.nanoTime() - start) * 10e-6) + " ms\n");

        start = System.nanoTime();
        System.out.println(findWordBM(word, fullStr));
        System.out.println("Execution time is " + formatter.format((System.nanoTime() - start) * 10e-6) + " ms");
    }

    private static int findWordBM(String word, String str) {
        char[] chars = str.toCharArray();
        char[] ch = word.toCharArray();
        int i = 0, cntr = 0;

        while (i < chars.length - ch.length) {
            boolean flag = false;
            for (int j = i + ch.length - 1; j >= i; j--) {
                if (chars[j] != ch[j - i]) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                cntr += 1;
                i += ch.length;
                continue;
            }

            i += 1;
        }

        return cntr;
    }

    private static int findWord(String word, String str) {
        char[] chars = str.toCharArray();
        char[] ch = word.toCharArray();
        int i = 0, cntr = 0;

        while (i < chars.length) {
            boolean flag = false;
            for (int j = i; j - i < ch.length; j++) {
                if (chars[j] != ch[j - i]) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                cntr += 1;
                i += ch.length;
                continue;
            }

            i += 1;
        }

        return cntr;
    }
}