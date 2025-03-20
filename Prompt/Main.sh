ChangePromptPath=./.ChangePrompt.sh
bashDir=~/

if [ ! -f $ChangePromptPath ] || [ ! -f $bashDir/.bashrc ]; then
    echo "Error. File required for program was not found."
    exit 1
fi

cp $ChangePromptPath $bashDir

chmod +x $ChangePromptPath

CodeForbashrc='export ChangePromptPath=$PWD/.ChangePrompt.sh
export PS1=$($ChangePromptPath)

cd() {
    builtin cd "$@"
    export PS1=$($ChangePromptPath)
}'

echo "$CodeForbashrc" >> $bashDir/.bashrc
