---
title: Basics
weight: 1
---

Let's get started with a few simple examples to understand how to use CodeWhisperer.

There are few common ways to use CodeWhisperer. The first is to simply allow CodeWhisperer to make recommendations as you type. Create a new file and save in a folder you prefer with name `tar_example1.sh`. In this example, you are uncompressing a tar file. Copy the lines below. If you place you cursor at the end of the second line and continue typing the command (enter "v") CodeWhisperer should recommend an option to complete the command. Hit Tab to accept the entry. A new suggestion should appear to enter in the uncompressed folder.

```bash
!/bin/bash
tar -x
```

::::expand{header="Solution"}

```bash
#!/bin/bash
tar -xvf /tmp/data.tar.gz -C /tmp
cd /tmp/data
```

::::

::alert[Please note that CodeWhisperer uses artificial intelligence to provide code recommendations and this is non-deterministic. This code might differ from what you get from Amazon CodeWhisperer in your case.]

The second way to interact with CodeWhisperer is to use comments. Comment our code is part of our day, so this should be natural. Create a new file named `printexample2.sh`. In this example, you added a comment to describe a Shell command you are about to create. If you place you cursor at the end of the second line and hit Enter to add a new line. CodeWhisperer should recommend a command to print the number of files. Hit Tab to accept the entry. If you hit enter again CodeWhisperer should recommend a sucessfull exit code.

```bash
#!/bin/bash
#print the number of files in the current directory
```

The third way is to force CodeWhisperer to offer a suggestion. Occasionally, CodeWhisperer does not have high confidence that it had recommendation offer. However, you can force it make a recommendation by hitting either Option + C on  MacOS or Alt + C on Windows. Create an empty file `emptyexample3.sh`. As the file is empty, CodeWhisperer cannot predict what you are trying to do. But, if you hit force the recommendation it should offer something. Try it out. CodeWhisperer will recommend to start the file with `#!/bin/bash`.

::alert[Please note that CodeWhisperer uses artificial intelligence to provide code recommendations and this is non-deterministic. This code might differ from what you get from Amazon CodeWhisperer in your case.]
