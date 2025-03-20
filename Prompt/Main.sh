# file : Main.sh
# author : psiblvdegod
# date : 2025
# under MIT license

# requires .GeneratePrompt.sh in the same directory for work.
# creates copy of .GeneratePrompt in bashDir directory,
# changes .bashrc so every time cd is called $PS1 changes to meet conditions of the task.

GeneratePromptPath=./.GeneratePrompt.sh
bashDir=~/

if [ ! -f $GeneratePromptPath ] || [ ! -f $bashDir/.bashrc ]; then
    echo "Error. File required for program was not found."
    exit 1
fi

cp $GeneratePromptPath $bashDir

chmod +x $GeneratePromptPath

CodeForbashrc='export GeneratePromptPath=$PWD/.GeneratePrompt.sh
export PS1=$($GeneratePromptPath)

cd() {
    builtin cd "$@"
    export PS1=$($GeneratePromptPath)
}'

echo "$CodeForbashrc" >> $bashDir/.bashrc
