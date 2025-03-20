# file : Main.sh
# author : psiblvdegod
# date : 2025
# under MIT license

# requires GeneratePrompt.sh in the same directory for work.
# changes .bashrc so every time cd is called $PS1 changes to meet conditions of the task.

GeneratePromptPath=./GeneratePrompt.sh
bashrcPath=~/.bashrc

if [ ! -f $GeneratePromptPath ] || [ ! -f $bashrcPath ]; then
    echo "Error. File required for program was not found."
    exit 1
fi

cat "$GeneratePromptPath" >> "$bashrcPath"

echo '
cd() {
    builtin cd "$@"
    export PS1=$(GeneratePrompt)
}' >> $bashrcPath