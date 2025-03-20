# author : psiblvdegod
# date : 2025
# under MIT license

# calculates and echo required value for $PS1
GeneratePrompt() {
	red="\e[1m\e[31m"
	blue="\e[1m\e[34m"
	end="\e[0m"
	GitStatus=$(git status --porcelain 2>/dev/null)

	if [ $? -eq 0 ]; then
		modified=$(echo "$GitStatus" | grep -E '^\s*M' | wc -l)
		untracked=$(echo "$GitStatus"| grep -E '^\s*\?' | wc -l)
		deleted=$(echo "$GitStatus" | grep -E '^\s*D' | wc -l)
		new=$(echo "$GitStatus" | grep -E '^\s*A' | wc -l)
		prompt="${blue}git:${end} modified:$red$modified$end untracked:$red$untracked$end deleted:$red$deleted$end new:$red$new$end\n$blue>$end "
	else
		size=$(df -h --output=size | awk 'NR==2' | tr -d ' ')
		used=$(df -h --output=used | awk 'NR==2' | tr -d ' ')
		files=$(($(ls -a -1 | wc -l) - 2))
		prompt="${blue}disk:${end} usage:$red$used/$size$end files:$red$files$end\n$blue>$end "
	fi

	echo -e "$prompt"
}

# changes $PS1 using GeneratePrompt() every time cd is called
cd() {
    builtin cd "$@"
    export PS1=$(GeneratePrompt)
}

cd .