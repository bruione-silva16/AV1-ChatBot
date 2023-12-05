public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- CHATBOT COM POO ---");

        ICanal whatsAppUser = new WhatsApp();
        ICanal InstaUser = new Instagram();


        MensagemBasica mensagem = new MensagemBasica();
        mensagem.DataEnvio = DateTime.Now;
        mensagem.Mensagem = "Olá, boa noite!";


        Video mensagemVideo = new Video();
        mensagem.DataEnvio = DateTime.Now;
        mensagem.Mensagem = "Boa Noite - Mensagem de vídeo";
        mensagemVideo.Arquivo = "QueroDormir.mp4";
        mensagemVideo.Formato = TiposDeArquivo.MP3;
        mensagemVideo.Duracao = 70;

        //Enviando mensagem básica
        whatsAppProfessor.EnviarMensagem("+5511964687373", mensagem);


        //Enviando mensagem de vídeo
        instaAluno.EnviarMensagem("+5511964687373", mensagemVideo);


        MensagemMultimidia mensagemPhelipe = mensagemVideo;
        mensagemCaio.Mensagem = "Olá, Phelipe!";

        ICanal facebook = new Facebook();
        facebook.EnviarMensagem("usuarioDoPhelipe", mensagemPhelipe);

        ICanal canal = Factory.Create("facebook");
    }
}

// --- Metódos do programa ---
public interface ICanal
{
    void EnviarMensagemBasica(string destinario, MensagemBasica mensagem);
    void EnviarMensagemMultimidia(string destinario, MensagemMultimidia mensagem);
    void EnviarMensagemVideo(string destinario, Video mensagem);
}

public enum TiposDeArquivo
{
    MP3,
    MP4,
    PDF
}

public static class Factory
{

    public static ICanal Create(string canal)
    {
        switch (canal)
        {
            case "whatsApp":
                return new WhatsApp();
            case "facebook":
                return new Facebook();
            default:
                return null;
                break;
        };
        return null;
    }
}


public abstract class CanaisMensagem : ICanal
{
    protected abstract string canal { get; }

    // --- Metódo para o envio de mensagem básica --- 
    public void EnviarMensagemBasica(string Destinario, MensagemBasica mensagem)
    {
        // --- Imprimindo a mensagem básica para o usuário ---
        Console.WriteLine("Envio da mensagem básica enviada pelo canal: " + canal);
        Console.WriteLine("Destinatário: " + destinatario);
        Console.WriteLine("Mensagem: " + mensagem.Mensagem);
        Console.WriteLine("Data Envio: " + mensagem.DataEnvio);
        Console.WriteLine("");
    }

    // --- Método para o envio de mensagem mulímídia ---
    public void EnviarMensagemMultimidia(string Destinario, MensagemMultimidia mensagem)
    {
        // --- Imprimindo a mensagem multimídia para o usuário ---
        Console.WriteLine("Envio da mensagem básica enviada pelo canal: " + canal);
        Console.WriteLine("Destinatário: " + destinatario);
        Console.WriteLine("Mensagem: " + mensagem.Mensagem);
        Console.WriteLine("Data Envio: " + mensagem.DataEnvio);
        Console.WriteLine("");
    }

    // --- Método para o envio de mensagem mulímídia ---
    public void EnviarMensagemVideo(string destinatario, Video mensagem)
    {
        // --- Imprimindo a mensagem vídeo para o usuário ---
        Console.WriteLine("Mensagem video enviada pelo canal: " + canal);
        Console.WriteLine("Destinatário: " + destinatario);
        Console.WriteLine("Mensagem: " + mensagem.Mensagem);
        Console.WriteLine("Data Envio: " + mensagem.DataEnvio);
        Console.WriteLine("Arquivo: " + mensagem.Arquivo);
        Console.WriteLine("Tipo Arquivo: " + mensagem.Formato);
        Console.WriteLine("Duração: " + mensagem.Duracao);
        Console.WriteLine("");
    }
}


public class WhatsApp : CanaisMensagem, ICanal
{
    protected override string canal { get { return "WhatsApp"; } }
}

public class Telegram : CanaisMensagem, ICanal
{
    protected override string canal { get { return "Telegram"; } }
}

public class Instagram : CanaisMensagem, ICanal
{
    protected override string canal { get { return "Instagram"; } }
}

public class Facebook : CanaisMensagem, ICanal
{
    protected override string canal { get { return "Facebook"; } }
}


public class MensagemBasica
{
    public string Mensagem { get; set; }
    public DateTime DataEnvio { get; set; }
}

public class MensagemMultimidia : MensagemBasica
{
    public string Arquivo { get; set; }
    public TiposDeArquivo Formato { get; set; }
}

public class Video : MensagemMultimidia
{
    public int Duracao { get; set};
}