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

ps 72413;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 72413 > /dev/null;
done;

for child in $(list_child_processes 72448);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/mac/Projects/WEB APPS/eMedicalWebManagement/src/Web/eMedicalManagementAngular/bin/Debug/net7.0/5ce3408205b9432b8b777e8c5a6b4434.sh;
