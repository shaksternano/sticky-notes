export interface NoteProps {
    text: string;
    color: string;
}

export default function NoteCard(props: NoteProps) {
    return (
        <article class={`note note-${props.color}`}>
            <span class="text-2xl">
                ✦
            </span>
            <p class="mt-6 text-lg font-medium leading-relaxed">
                {props.text}
            </p>
        </article>
    );
}
