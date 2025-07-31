using AesTextEncryptor.Services; 

namespace AesTextEncryptor;

public partial class MainPage : ContentPage
{
    private readonly byte[] aesKey;
    private readonly byte[] aesIV;
    private string encryptedText;

    public MainPage()
    {
        InitializeComponent();
        aesKey = AesEncryption.GenerateRandomKey();
        aesIV = AesEncryption.GenerateRandomIV();
    }

    // Encrypt Button Click
    private void OnEncryptClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(InputText.Text))
        {
            DisplayAlert("Error", "Please enter text to encrypt.", "OK");
            return;
        }

        encryptedText = AesEncryption.Encrypt(InputText.Text, aesKey, aesIV);
        EncryptedLabel.Text = encryptedText;
    }

    // Decrypt Button Click
    private void OnDecryptClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(encryptedText))
        {
            DisplayAlert("Error", "No encrypted text to decrypt.", "OK");
            return;
        }

        string decryptedText = AesEncryption.Decrypt(encryptedText, aesKey, aesIV);
        DecryptedLabel.Text = decryptedText;
    }
}
