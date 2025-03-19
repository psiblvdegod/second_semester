ChangePromptPath=./ChangePrompt.sh
bashDir=~/

if [ ! -f $ChangePromptPath ] || [ ! -f $bashDir/.bashrc ]; then
    echo "Error. File required for program was not found."
    exit 1
fi

cp $ChangePromptPath $bashDir

CodeForbashrc='export ChangePromptPath=./ChangePrompt.sh

cd() {
    builtin cd "$@"
    export PS1=$($ChangePromptPath)
}'

echo "$CodeForbashrc" >> $bashDir/.bashrc