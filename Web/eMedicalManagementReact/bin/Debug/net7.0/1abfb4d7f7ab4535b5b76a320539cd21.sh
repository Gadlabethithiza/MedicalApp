function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 9113;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 9113 > /dev/null;
done;

for child in $(list_child_processes 9136);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/mac/Projects/WEB APPS/eMedicalWebManagement/src/Web/eMedicalManagementReact/bin/Debug/net7.0/1abfb4d7f7ab4535b5b76a320539cd21.sh;
