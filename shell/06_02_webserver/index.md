---
title: Setup a webserver
weight: 2
---

Now that you already have some experience creating Shell script with Amazon CodeWhisperer, you will try CodeWhisperer in a few challenges. Let's start setuping a webserver instance which is a common task.

CodeWhisperer is designed to improve your productivity. You are not going to experience that productivity gain following step-by-step instructions. Don’t worry, we have provided a few hints to help you along way if you get stuck.

## Challenge

Create a file called `webserver.sh` to install all the components on the webserver to run php and httpd. Create a hello_world page with the instance id and start the components.

### Hint

Start with "#!/bin/bash", updating yum repository and installing httpd and php.

::alert[Please don't start the components yet as we will create the hello_world file.]

```bash
#!/bin/bash
#update yum
...
```

::::expand{header="Solution"}

```bash
#!/bin/bash
#update yum
yum update -y
#install httpd
yum install httpd -y
#install php
yum install php php-mysql -y
```

::::

Now we will complete the file by requesting to create hello_world.php file. Should create it manually? NO! Let's make CodeWhisperer create it for us by adding the instructions in the webserver.sh.

We already have the installation part of the file, let's create a comment for the CodeWhisperer to create the file.

```bash
#!/bin/bash
#update yum
yum update -y
#install httpd
yum install httpd -y
#install php
yum install php php-mysql -y
??????????
```

::::expand{header="Solution"}

```bash
#!/bin/bash
#update yum
yum update -y
#install httpd
yum install httpd -y
#install php
yum install php php-mysql -y
#create a hello_world.php
cat <<EOF > /var/www/html/hello_world.php
<?php
echo "Hello World";
\$output = shell_exec('echo $HOSTNAME');
echo "<pre>$output</pre>";
?>
EOF
```

::::

Now it is time to start our webserver. Let's comment and also start writting the command, so CodeWhisperer can complete. Also, enable httpd and print the service status.

```bash
#!/bin/bash
#update yum
yum update -y
#install httpd
yum install httpd -y
#install php
yum install php php-mysql -y
#create a hello_world.php
cat <<EOF > /var/www/html/hello_world.php
<?php
echo "Hello World";
\$output = shell_exec('echo $HOSTNAME');
echo "<pre>$output</pre>";
?>
EOF
#start webserver
systemctl <CodeWhisperer will complete with the solution>
```

::::expand{header="Solution"}

```bash
#!/bin/bash
#update yum
yum update -y
#install httpd
yum install httpd -y
#install php
yum install php php-mysql -y
#create a hello_world.php
cat <<EOF > /var/www/html/hello_world.php
<?php
echo "Hello World";
\$output = shell_exec('echo $HOSTNAME');
echo "<pre>$output</pre>";
?>
EOF
#start webserver
systemctl start httpd
#enable webserver
systemctl enable httpd
#check status
systemctl status httpd
```

::::

## Success!

Done!!! Now you have created the Shell Script to install, create a sample page and start/enable the webserver. Try to run it in a test EC2 instance if you have availability.