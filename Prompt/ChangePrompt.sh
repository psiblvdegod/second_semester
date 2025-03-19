git_status="$(git status --porcelain)"
red="\e[1m\e[31m"
end="\e[0m"

if [ $? -eq 0 ]; then
	number_of_modified=$(echo "$git_status" | grep -E '^ M' | wc -l)
	number_of_untracked=$(echo "$git_status"| grep -E '^\?\?' | wc -l)
	prompt="modified:$red$number_of_modified$end untracked:$red$number_of_untracked$end $ "
else
	size=$(df -h --output=size | awk 'NR==2' | tr -d ' ')
	used=$(df -h --output=used | awk 'NR==2' | tr -d ' ')
	number_of_files=$(ls -1 | wc -l)
	prompt="usage:$red$used/$size$end files:$red$number_of_files$end $ "
fi

echo -e "$prompt"
