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

ps 8501;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 8501 > /dev/null;
done;

for child in $(list_child_processes 8621);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/mac/Projects/WEB APPS/eMedicalWebManagement/src/Web/eMedicalManagementAngular/bin/Debug/net7.0/d534b6e442e644c7b217cc5e425439f3.sh;
