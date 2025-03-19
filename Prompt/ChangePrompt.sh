GIT_STATUS=$(git status)

if [ $? != 0 ]; then
    echo "Репозиторий в порядке."
else
	available_space=$(df -h --output=avail | awk 'NR==2')
	number_of_files=$(ls -1 | wc -l)
	prompt="s:\e[31m$available_space\e[0m f:\e[32m$number_of_files\e[0m" 

fi

echo -e $prompt
